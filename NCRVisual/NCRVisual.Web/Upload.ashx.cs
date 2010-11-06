﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NCRVisual.Web.Controllers;

namespace NCRVisual.Web
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        string ClientBinPath = ""; //path to store input and output data data
        string fileName = "";

        public void ProcessRequest(HttpContext context)
        {
            ClientBinPath = context.Server.MapPath("~/Output/");

            string filename = context.Request.QueryString["filename"].ToString();
            string outputFileName=context.Request.QueryString["output"];
            if (outputFileName==null||outputFileName=="")
                outputFileName="output";

            using (FileStream fs = File.Create(context.Server.MapPath("~/Output/" + filename)))
            {
                SaveFile(context.Request.InputStream, fs);
            }

            DataInputController controller = new DataInputController();
            controller.OutputFileName = outputFileName;
            controller.SolveData(ClientBinPath, filename);

            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        private void SaveFile(Stream stream, FileStream fs)
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                fs.Write(buffer, 0, bytesRead);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}