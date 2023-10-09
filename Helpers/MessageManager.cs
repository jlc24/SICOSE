using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICOSE.Helpers
{
    internal class MessageManager
    {
        public const string msg_FP_InitComplete = "Inicialización completada";

        public const string msg_FP_NotConnected = "Ningún dispositivo conectado !!";

        public const string msg_FP_PressForVerification = "Por favor presione su dedo para verificar !";

        public const string msg_FP_PressForIdentification = "Por favor presione su dedo para identificarlo. !";

        public const string msg_FP_CurrentFingerAlreadyRegistered = "Este dedo ya está registrado con id. ";

        public const string msg_FP_EnrollSuccessfull = "Huella digital registrado exitosamente.";

        public const string msg_FP_FailedToAddTemplate = "Failed to add the users template";

        public const string msg_FP_UnableToEnrollCurrentUser = "Unable to enroll the current user. Error Code: ";

        public const string msg_FP_MatchSuccess = "Identificacion Exitosa. Puntaje: ";

        public const string msg_FP_MatchFailed = "Fallo de identificacion. Puntaje: ";

        public const string msg_FP_IdentificationSuccess = "Identification Failed. Score: ";

        public const string msg_FP_IdentificationFailed = "Identification Failed. Score: ";

        public const string msg_FP_UnidentifiedFingerPrint = "Huella Digital no identificada. Por favor registrar.";

        public const string msg_FP_Disconnected = "Te has desconectado del dispositivo. ";

        public const string msg_FP_FailedToReleaseResources = "Failed to release the resources !!";

        public const string msg_FP_UnableToDeleteFingerPrint = "No se puede eliminar la huella digital con identificación ";
    }
}
