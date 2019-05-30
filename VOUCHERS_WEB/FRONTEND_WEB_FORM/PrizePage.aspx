<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrizePage.aspx.cs" Inherits="FRONTEND_WEB_FORM.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <title>Sorteo Promocional</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    </head>
    <body>
        <panel id="pnlPremios" runat="server">
        <div class="header-container d-flex flex-direction-column">
            <label class="header">Sorteo</label>
            <label class="sub-header">Elija su premio</label>
        </div>

      


        <div class=" d-flex justify-content-center">
            
                        <asp:TemplateField HeaderText="Reporting Status">
                              <tr>
                            <td class="">
                                 <ItemTemplate >
                        <asp:Image ID="prize1" class="mr-2"  runat="server" ImageUrl="~/images/mayonesa.jpg"></asp:Image>
                              </ItemTemplate>
                            </td>
                            <td class="">
                                  <ItemTemplate>
                        <asp:Image ID="Prize2" class="mr-2" runat="server" ImageUrl="~/images/Barbacoa.jpg"></asp:Image>
                              </ItemTemplate>
                            </td>
                                   <td class="">
                                  <ItemTemplate>
                        <asp:Image ID="Prize3" class="mr-2" runat="server" ImageUrl="~/images/Ketchup.jpg"></asp:Image>
                              </ItemTemplate>
                            </td>
                                   </td>
                                   <td class="">
                                  <ItemTemplate>
                        <asp:Image ID="Prize4" class="mr-2" runat="server" ImageUrl="~/images/Salsagolf.jpg"></asp:Image>
                              </ItemTemplate>
                            </td>
                                   </td>
                                   <td class="">
                                  <ItemTemplate>
                        <asp:Image ID="Prize5" class="mr-2" runat="server" ImageUrl="~/images/Mostaza.jpg"></asp:Image>
                              </ItemTemplate>
                            </td>
                        </tr>

                              
        
                    

 </asp:TemplateField>
         
                        
                    </div>

            <div class="d-flex justify-content-center">

                
                       
                        <input type="button" class="auth-btn mt-4 mr-3" value="Elegir" runat="server" id="btnAuth" onserverclick="btnAuth_ServerClick"/>
                    
                             
                      
                        <input type="button" class="auth-btn mt-4 ml-2 mr-3" value="Elegir" runat="server" id="Button1" onserverclick="btnAuth_ServerClick"/>
                   
                             
                       
                        <input type="button" class="auth-btn mt-4 ml-2 mr-3" value="Elegir" runat="server" id="Button2" onserverclick="btnAuth_ServerClick"/>



                <input type="button" class="auth-btn mt-4 ml-2 mr-2" value="Elegir" runat="server" id="Button3" onserverclick="btnAuth_ServerClick"/>



                <input type="button" class="auth-btn mt-4 ml-3" value="Elegir" runat="server" id="Button4" onserverclick="btnAuth_ServerClick"/>
              
                    

            </div>
         
    </panel>


         <panel id="pnlCarga" runat="server" visible="false">
        <div class="header-container d-flex flex-direction-column">
            <label class="header">Sorteo</label>
            <label class="sub-header">Carga de Datos</label>
        </div>
        <div class=" d-flex justify-content-center">
            <div class="d-flex flex-direction-column">
                
                <div class="input-container d-flex flex-direction-column">
                    <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Nombre" runat="server" id="user"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Apellido" runat="server" id="Text1"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Direccion" runat="server" id="Text2"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Localidad" runat="server" id="Text5"/>                       
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Email" runat="server" id="Text3"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="Telefono" runat="server" id="Text4"/>
                        
                    </div>
                   
                    <div class="d-flex justify-content-center">
                        <input type="button" class="auth-btn mt-4 mr-5" value="Aceptar" runat="server" id="Button5" onserverclick="btnLoad_ServerClick"/>
                        <input type="button" class="auth-btn mt-4 ml-5" value="Cancelar" runat="server" id="Button6" onserverclick="btnCancel_ServerClick"/>
                    </div>

                    
                </div>
            </div>
        </div>
    </panel>

    </body>














</asp:Content>
