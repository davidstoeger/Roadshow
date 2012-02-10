<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sitecore.Roadshow.Profiling.Default" %>
<%@ Import Namespace="Sitecore.Marketing.Profiles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">                  
  <head>
    <title>Profile Pattern Viewer</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/default.css" rel="stylesheet" />
    <!--[if IE]>
			<script type="text/javascript" src="/sitecore/shell/Applications/Analytics/Personalization/Chart/excanvas.js"></script>
			<script type="text/javascript" src="/sitecore/shell/Applications/Analytics/Personalization/Chart/base64.js"></script>
		<![endif]-->
    <script type="text/javascript" src="/sitecore/shell/Applications/Analytics/Personalization/Chart/canvas2image.js"></script>
    <script type="text/javascript" src="/sitecore/shell/Applications/Analytics/Personalization/Chart/canvastext.js"></script>
    <script type="text/javascript" src="/sitecore/shell/controls/lib/prototype/prototype.js"></script>
    <script type="text/javascript" src="/sitecore/shell/Applications/Analytics/Personalization/Chart/flotr.js"></script>
    <style type="text/css">
    .flotr-legend-label
    {
        font-size:inherit;
    }
    </style>
  </head>
  <body>
    <div>
        <asp:Literal ID="litUserLocation" runat="server"></asp:Literal>
    </div>
    <script type="text/javascript">
        function CreateChartDiv(profileName, width, height, fontSize) {
            var div = document.createElement("div");
            document.body.appendChild(div);
            var radarChart = parent.document.getElementById('radarChart' + profileName);
            if (radarChart != null) {
                width = radarChart.offsetWidth - 100;
                height = width / 2;
                radarChart.height = height + 100;
            }
            div.setAttribute('style', 'width:' + width + 'px;height:' + height + 'px;font-size:' + (fontSize + 3) + 'pt;');
            return div;
        }

        //RadarChart2.html?value=profileName=aaa;total=100;a=1;b=2;c=3;d=4;e=5
        //RadarChart2.html?sets=people;places;things&value=profileName=aaa;total=100;a=1;b=2;c=3;d=4;e=5
        document.observe('dom:loaded', function initialize() {
        <%
            var helper = new RadarChartHelper();
            Response.Write(helper.DisplayRadarCharts(600, 400));
        %>
        });
    </script>
  </body>
</html>

