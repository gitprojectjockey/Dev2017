using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CustomerFileContext.BaseClasses
{
    public abstract class XMLFileServiceBase
    {
        public XDocument Load(string fileName)
        {
            return XDocument.Load(fileName);
        }

        public virtual XDocument Load(Uri uri)
        {
            try
            {
                if (!uri.IsFile)
                {
                    throw new IOException("The specified URI is not a valid File Uri.");
                }
                return XDocument.Load(uri.AbsolutePath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch
            {
                throw;
            }
        }

        public virtual XDocument Load(Stream fileStream)
        {
            try
            {
                return XDocument.Load(fileStream);
            }
            catch
            {
                throw;
            }
        }

        public virtual XDocument Load(TextReader textReader)
        {
            try
            {
                return XDocument.Load(textReader);
            }
            catch
            {
                throw;
            }
        }

        public virtual XDocument Load(XmlReader xmlReader)
        {
            try
            {
                return XDocument.Load(xmlReader);
            }
            catch
            {
                throw;
            }
        }

        public abstract void Dispose();

        public virtual bool IsSchemaValid(string schemaFile, XDocument document, out string schemaErrors)
        {
            schemaErrors = string.Empty;
            var errorInfo = string.Empty;
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", schemaFile);
            document.Validate(schemas, (o, e) =>
            {
                errorInfo = e.Message;
            });
            schemaErrors = errorInfo;
            return errorInfo.Length > 0 ? false : true;
        }
    }
}
