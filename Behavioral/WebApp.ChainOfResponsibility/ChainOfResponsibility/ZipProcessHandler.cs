using System.IO.Compression;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class ZipProcessHandler<T>:ProcessHandler
    {
        public override object handle(object o)
        {
            var excelMemoryStream = o as MemoryStream;

            excelMemoryStream.Position = 0;

            using (var zipStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    var zipFile = zipArchive.CreateEntry($"{typeof(T).Name}.xlsx");

                    using (var zipEntry = zipFile.Open())
                    {
                        excelMemoryStream.CopyTo(zipEntry);
                    }
                }

                return base.handle(zipStream);
            }
        }
    }
}
