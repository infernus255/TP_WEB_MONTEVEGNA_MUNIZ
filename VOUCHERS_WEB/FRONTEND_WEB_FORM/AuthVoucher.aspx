<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthVoucher.aspx.cs" Inherits="FRONTEND_WEB_FORM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <head>
    <title>Sorteo Promocional</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
</head>
<body>
    <panel id="pnllogin" runat="server">
        <div class="header-container d-flex flex-direction-column">
            <label class="header">Sorteo</label>
            <label class="sub-header">Autenticacion de Voucher</label>
        </div>
        <div class=" d-flex justify-content-center">
            <div class="d-flex flex-direction-column">
                
                <div class="input-container d-flex flex-direction-column">
                    <div class="d-flex justify-content-center">
                        <input type="text" class="input-text" placeholder="Inserte Codigo Promocional" runat="server" id="txtvoucher" maxlength="8" />
                        
                    </div>
                   
                    
                    <div class="d-flex justify-content-center">
                        <asp:label class="sub-header" runat="server" Visible="false" ID="lblfail"> VOUCHER INVALIDO, INGRESE UN CODIGO PARTICIPANTE </asp:label>
                    </div>

                    <div class="d-flex justify-content-center">
                        <input type="button" class="auth-btn mt-4" value="Verificar" runat="server" id="btnAuth" onserverclick="btnAuth_ServerClick"/>
                    </div>
                    
                </div>
            </div>
        </div>
    </panel>
</body>



</asp:Content>
