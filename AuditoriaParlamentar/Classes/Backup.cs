using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace AuditoriaParlamentar.Classes
{
    public class Backup
    {
        internal void FazerBackup(String dir)
        {
            using (Banco banco = new Banco())
            {
                banco.GetTable("SELECT * FROM denuncias", 300).WriteXml(dir + @"\denuncias.xml");
                banco.GetTable("SELECT * FROM denuncias_anexo", 300).WriteXml(dir + @"\denuncias_anexo.xml");
                banco.GetTable("SELECT * FROM denuncias_msg", 300).WriteXml(dir + @"\denuncias_msg.xml");
                banco.GetTable("SELECT * FROM despesas", 300).WriteXml(dir + @"\despesas.xml");
                banco.GetTable("SELECT * FROM despesas_senadores", 300).WriteXml(dir + @"\despesas_senadores.xml");
                banco.GetTable("SELECT * FROM fornecedores_visitado", 300).WriteXml(dir + @"\fornecedores_visitado.xml");
                banco.GetTable("SELECT * FROM noticias", 300).WriteXml(dir + @"\noticias.xml");
                banco.GetTable("SELECT * FROM notificacoes", 300).WriteXml(dir + @"\notificacoes.xml");
                banco.GetTable("SELECT * FROM parametros", 300).WriteXml(dir + @"\parametros.xml");
                banco.GetTable("SELECT * FROM parlamentares", 300).WriteXml(dir + @"\parlamentares.xml");
                banco.GetTable("SELECT * FROM partidos", 300).WriteXml(dir + @"\partidos.xml");
                banco.GetTable("SELECT * FROM partidos_senadores", 300).WriteXml(dir + @"\partidos_senadores.xml");
                banco.GetTable("SELECT * FROM roles", 300).WriteXml(dir + @"\roles.xml");
                banco.GetTable("SELECT * FROM senadores", 300).WriteXml(dir + @"\senadores.xml");
                banco.GetTable("SELECT * FROM users", 300).WriteXml(dir + @"\users.xml");
                banco.GetTable("SELECT * FROM usersinroles", 300).WriteXml(dir + @"\usersinroles.xml");
                banco.GetTable("SELECT * FROM users_detail", 300).WriteXml(dir + @"\users_detail.xml");
            }

            ZipFile zip = ICSharpCode.SharpZipLib.Zip.ZipFile.Create(dir + @"\backup-" + DateTime.Now.ToString("yyyy-MM-dd") + ".zip");
            zip.BeginUpdate();
            
            DirectoryInfo dirInfor = new DirectoryInfo(dir);

            foreach (FileInfo fileInfo in dirInfor.GetFiles("*.xml"))
                zip.Add(fileInfo.FullName, CompressionMethod.WinZipAES);

            zip.CommitUpdate();
            zip.Close();

            foreach (FileInfo fileInfo in dirInfor.GetFiles("*.xml"))
                fileInfo.Delete();
        }
    }
}