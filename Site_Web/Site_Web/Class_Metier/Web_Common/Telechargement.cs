using System;
using System.IO;
using System.Net;
using System.Web;

namespace Site_Web.Class_Metier.Web_Common
{
    /// <summary>
    /// Classe utilitaire contenant des fonction statique lié au Email
    /// </summary>
    public class Telechargement
    {
        /// <summary>
        /// Permet a l'utilisateur de télécharger un fichier.
        /// </summary>
        /// <param name="pResp">Objet Response lié au controller</param>
        /// <param name="pFileName">Nom du fichier que l'utilisateur aura au téléchargement</param>
        /// <param name="pUrl">L'url source du fichier</param>
        public static void telechargementWeb(HttpResponseBase pResp, string pFileName, string pUrl)
        {
            //Create a stream for the file
            Stream stream = null;

            //This controls how many bytes to read at a time and send to the client
            int bytesToRead = 10000;

            // Buffer to read bytes in chunk size specified above
            byte[] buffer = new Byte[bytesToRead];

               // The number of bytes read
            try
            {
                //Create a WebRequest to get the file
                HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(pUrl);

                //Create a response for this request
                HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();

                if (fileReq.ContentLength > 0)
                    fileResp.ContentLength = fileReq.ContentLength;

                //Get the Stream returned from the response
                stream = fileResp.GetResponseStream();
            
                //Indicate the type of data being sent
                pResp.ContentType = "application/octet-stream";

                //Name the file 
                pResp.AddHeader("Content-Disposition", "attachment; filename=\"" + pFileName + "\"");
                pResp.AddHeader("Content-Length", fileResp.ContentLength.ToString());

                int length;
                do
                {
                    // Verify that the client is connected.
                    if (pResp.IsClientConnected)
                    {
                        // Read data into the buffer.
                        length = stream.Read(buffer, 0, bytesToRead);

                        // and write it out to the response's output stream
                        pResp.OutputStream.Write(buffer, 0, length);

                        // Flush the data
                        pResp.Flush();

                        //Clear the buffer
                        buffer = new Byte[bytesToRead];
                    }
                    else
                    {
                        // cancel the download if client has disconnected
                        length = -1;
                    }
                } while (length > 0); //Repeat until no data is read
            }
            finally
            {
                if (stream != null)
                {
                    //Close the input stream
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Permet a l'utilisateur de télécharger un fichier.
        /// </summary>
        /// <param name="pResp">Objet Response lié au controller</param>
        /// <param name="pFileName">Nom du fichier que l'utilisateur aura au téléchargement</param>
        /// <param name="pPath">Le path server du fichier</param>
        public static void telechargementLocal(HttpResponseBase pResp, string pFileName, string pPath)
        {
            string filename = pPath ;
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                pResp.Clear();
                pResp.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                pResp.AddHeader("Content-Length", fileInfo.Length.ToString());
                pResp.ContentType = "application/octet-stream";
                pResp.Flush();
                pResp.TransmitFile(fileInfo.FullName);
                pResp.End();
            }
            else
            {
                Console.Error.WriteLine("File not found", pPath);
            }
        }
    }
}