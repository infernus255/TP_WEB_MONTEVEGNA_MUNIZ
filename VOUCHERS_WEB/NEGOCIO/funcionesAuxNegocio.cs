﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace NEGOCIO
{
    public class funcionesAuxNegocio
    {
        public bool validarNumeros(string texto)
        {
            bool result = false;

            texto = texto.Replace(" ", "");

            if (texto.Length > 0)
            {
                result = true;

                for (int i = 0; i < texto.Length; i++)
                {
                    if (texto[i] > 57 || texto[i] < 48)
                    {
                        result = false;
                        return result;
                    }

                }
            }


            return result;

        }
        

        public bool validarLetras(string texto)
        {
            bool result = false;

            texto = texto.Replace(" ","");

            if (texto.Length > 0)
            {
               
                result = true;
                
                for (int i = 0; i < texto.Length; i++)
                {
                    if ( texto[i] < 65 || texto[i] > 122 || (texto[i]>90 && texto[i]<97) )
                    {
                        result = false;
                        return result;
                    }

                }
            }


            return result;

        }

        public bool validarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public void email_send(string emailPropio,string contrasena,string emailAEnviar, string titulo, string mensaje, string urlArchivo)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //SmtpClient SmtpServer = new SmtpClient("smtp.hotmail.com");
            mail.From = new MailAddress(emailPropio);
            mail.To.Add(emailAEnviar);
            mail.Subject = titulo;
            mail.Body = mensaje;

            if(urlArchivo!="")
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(urlArchivo);
                mail.Attachments.Add(attachment);
            }


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailPropio, contrasena);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}
