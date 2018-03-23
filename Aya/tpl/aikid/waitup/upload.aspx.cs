using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tpl_aikid_waitup_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(file.FileName)) {
            string[] type = file.FileName.Split('.');
            string fileType = type[type.Length - 1];
            if (fileType.ToLower() == "jpg" || fileType.ToLower() == "png" || fileType.ToLower() == "gif")
            {
                string fileName = Guid.NewGuid().ToString() + "." + fileType;
                file.SaveAs("C:\\web\\akidImg\\" + fileName);
                Response.Write("https://www.aikid360.com:8010/" + fileName);
            }
            else {
                Response.Write("图片格式不对");
            }
        }
    }
}