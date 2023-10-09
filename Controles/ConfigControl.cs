using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libzkfpcsharp;
using SICOSE;
using SICOSE.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace SICOSE.Controles
{
    public partial class ConfigControl : UserControl
    {

        public Home HomeForm { get; set; }
        const string VerifyButtonDefault = "Verificar";
        const string VerifyButtonToggle = "Detener Verificacion";
        const string Disconnected = "Desconectar";

        Thread captureThread = null;

        public Home parentForm = null;

        const int REGISTER_FINGER_COUNT = 3;

        zkfp fpInstance = new zkfp();
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        //byte[] FPBuffer;
        int RegisterCount = 0;

        byte[][] RegTmps = new byte[REGISTER_FINGER_COUNT][];

        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int regTempLen = 0;
        int iFid = 1;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        private int mfpWidth = 0;
        private int mfpHeight = 0;
        byte[] FPBuffer;

        public ConfigControl()
        {
            InitializeComponent();
        }

        private void cmbldx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConectarLector_Click(object sender, EventArgs e)
        {
            cmbldx.Items.Clear();

            int initializeCallBackCode = fpInstance.Initialize();

            if (zkfp.ZKFP_ERR_OK == initializeCallBackCode)
            {
                int nCount = fpInstance.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int i = 1; i <= nCount; i++) cmbldx.Items.Add(i.ToString());

                    cmbldx.SelectedIndex = 0;
                    btnConectarLector.Enabled = false;
                    btnDesconectarLector.Enabled = true;

                    parentForm.statusBar.Visible = true;
                    parentForm.btnPeatones.Enabled = true;

                    StatusBarMessage(MessageManager.msg_FP_InitComplete, "success");
                }
                else
                {
                    int finalizeCount = fpInstance.Finalize();
                    StatusBarMessage(MessageManager.msg_FP_NotConnected, "error");
                }

                int openDeviceCallBackCode = fpInstance.OpenDevice(cmbldx.SelectedIndex);
                if (zkfp.ZKFP_ERR_OK != openDeviceCallBackCode)
                {
                    string texto = $"Uable to connect with the device! (Return Code: {openDeviceCallBackCode} )";
                    StatusBarMessage(texto, "error");
                    return;
                }

                RegisterCount = 0;
                regTempLen = 0;
                iFid = 1;

                for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
                {
                    RegTmps[i] = new byte[2048];
                }

                byte[] paramValue = new byte[4];
                int size = 4;

                fpInstance.GetParameters(1, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                size = 4;
                fpInstance.GetParameters(1, paramValue, ref size);
                zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                FPBuffer = new byte[mfpWidth * mfpHeight];

                captureThread = new Thread(new ThreadStart(DoCapture));
                captureThread.IsBackground = true;
                captureThread.Start();

                bIsTimeToDie = false;

                string devSN = fpInstance.devSn;
                lblDeviceStatus.Text = "Conectado \nDispositivo S.No: " + devSN;

                if (parentForm != null)
                {
                    parentForm.lblStatusDevice.BackColor = System.Drawing.ColorTranslator.FromHtml("#4FD09A");
                    parentForm.lblStatusDevice.ForeColor = Color.White;
                    parentForm.lblStatusDevice.Text = "CONECTADO  -  Dispositivo S.No: " + devSN;
                }
            }
            else
            {
                string texto = "No se puede inicializar el dispositivo. " + FingerPrintDeviceUtilities.DisplayDeviceErrorByCode(initializeCallBackCode) + " !! ";
                StatusBarMessage(texto, "error");
            }
        }

        private void StatusBarMessage(string texto, string estado)
        {
            parentForm.statusBar.ForeColor = Color.White;
            parentForm.statusBar.Text = texto;
            if (estado == "success")
                parentForm.statusBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#4FD09A");
            else if (estado == "error")
                parentForm.statusBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67086");
            else if (estado == "info")
                parentForm.statusBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#3C8DBC");
        }

        private void DoCapture()
        {
            try
            {
                while (!bIsTimeToDie)
                {
                    cbCapTmp = 2048;
                    int ret = fpInstance.AcquireFingerprint(FPBuffer, CapTmp, ref cbCapTmp);

                    if (ret == zkfp.ZKFP_ERR_OK)
                    {
                        SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    }
                    Thread.Sleep(100);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]

        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        DisplayFingerPrintImage();
                        if (IsRegister)
                        {
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = fpInstance.Identify(CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                int deleteCode = fpInstance.DelRegTemplate(fid);   // <---- REMOVE FINGERPRINT
                                if (deleteCode != zkfp.ZKFP_ERR_OK)
                                {
                                    StatusBarMessage(MessageManager.msg_FP_CurrentFingerAlreadyRegistered + fid, "error");
                                    return;
                                }
                            }
                            if (RegisterCount > 0 && fpInstance.Match(CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                string texto = "Por favor presione el mismo dedo " + REGISTER_FINGER_COUNT + " tiempos de inscripción";
                                StatusBarMessage(texto, "info");
                                return;
                            }
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);


                            //if (RegisterCount == 0) btnEnroll.Enabled = false;

                            RegisterCount++;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {

                                RegisterCount = 0;
                                ret = GenerateRegisteredFingerPrint();   // <--- GENERATE FINGERPRINT TEMPLATE

                                if (zkfp.ZKFP_ERR_OK == ret)
                                {

                                    ret = AddTemplateToMemory();        //  <--- LOAD TEMPLATE TO MEMORY
                                    if (zkfp.ZKFP_ERR_OK == ret)         // <--- ENROLL SUCCESSFULL
                                    {
                                        string fingerPrintTemplate = string.Empty;
                                        zkfp.Blob2Base64String(RegTmp, regTempLen, ref fingerPrintTemplate);

                                        //Utilities.EnableControls(true, btnVerify, btnIdentify);
                                        //Utilities.EnableControls(false, btnEnroll);


                                        // GET THE TEMPLATE HERE : fingerPrintTemplate

                                        StatusBarMessage(MessageManager.msg_FP_EnrollSuccessfull, "success");

                                        //DisconnectFingerPrintCounter();
                                    }
                                    else
                                    {
                                        StatusBarMessage(MessageManager.msg_FP_FailedToAddTemplate, "error");
                                    }
                                }
                                else
                                {
                                    StatusBarMessage(MessageManager.msg_FP_UnableToEnrollCurrentUser + ret, "error");
                                }


                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                int remainingCont = REGISTER_FINGER_COUNT - RegisterCount;
                                //lblFingerPrintCount.Text = remainingCont.ToString();
                                string message = "Por favor proporcione su huella digital " + remainingCont + " veces mas";
                                StatusBarMessage(message, "info");

                            }
                        }
                        else
                        {
                            if (regTempLen <= 0)
                            {
                                StatusBarMessage(MessageManager.msg_FP_UnidentifiedFingerPrint, "error");
                                return;
                            }

                            if (bIdentify)
                            {
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = fpInstance.Identify(CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    StatusBarMessage(MessageManager.msg_FP_IdentificationSuccess + ret, "success");
                                    return;
                                }
                                else
                                {
                                    StatusBarMessage(MessageManager.msg_FP_IdentificationFailed + ret, "error");
                                    return;
                                }
                            }
                            else
                            {
                                int ret = fpInstance.Match(CapTmp, RegTmp);
                                if (0 < ret)
                                {
                                    StatusBarMessage(MessageManager.msg_FP_MatchSuccess + ret, "success");
                                    return;
                                }
                                else
                                {
                                    StatusBarMessage(MessageManager.msg_FP_MatchFailed + ret, "error");
                                    return;
                                }
                            }
                        }

                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void DisconnectFingerPrintCounter()
        {
            throw new NotImplementedException();
        }

        private int AddTemplateToMemory()
        {
            return fpInstance.AddRegTemplate(iFid, RegTmp);
        }

        private int GenerateRegisteredFingerPrint()
        {
            return fpInstance.GenerateRegTemplate(RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref regTempLen);
        }

        private void btnDesconectarLector_Click(object sender, EventArgs e)
        {
            OnDisconnect();
        }

        public void OnDisconnect()
        {
            bIsTimeToDie = true;
            RegisterCount = 0;
            ClearImage();
            Thread.Sleep(1000);
            int result = fpInstance.CloseDevice();

            //captureThread.Abort();
            if (result == zkfp.ZKFP_ERR_OK)
            {
                lblDeviceStatus.Text = "Dispositivo Desconectado";
                Thread.Sleep(1000);
                result = fpInstance.Finalize();
                if (result == zkfp.ZKFP_ERR_OK)
                {
                    regTempLen = 0;
                    IsRegister = false;
                    cmbldx.Items.Clear();

                    btnDesconectarLector.Enabled = false;
                    btnConectarLector.Enabled = true;
                    parentForm.statusBar.Visible = false;
                    parentForm.btnPeatones.Enabled = false;

                    parentForm.lblStatusDevice.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67086");
                    parentForm.lblStatusDevice.ForeColor = Color.White;
                    parentForm.lblStatusDevice.Text = "Dispositivo Desconectado";
                }
                else
                {
                    parentForm.lblStatusDevice.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67086");
                    parentForm.lblStatusDevice.ForeColor = Color.White;
                    parentForm.lblStatusDevice.Text = "Fallo al desconectar dispositivo";
                }
            }
            else
            {
                StatusBarMessage(FingerPrintDeviceUtilities.DisplayDeviceErrorByCode(result), "error");
            }
        }

        private void ClearImage()
        {
            picFPImg.Image = null;
        }

        private void DisplayFingerPrintImage()
        {
            MemoryStream ms = new MemoryStream();
            BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
            Bitmap bmp = new Bitmap(ms);
            this.picFPImg.Image = bmp;
        }

        private void ConfigControl_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }
    }
}
