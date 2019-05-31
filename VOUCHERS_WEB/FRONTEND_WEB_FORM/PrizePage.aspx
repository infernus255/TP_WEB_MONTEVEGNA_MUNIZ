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

                
                       
                        <input type="button"  class="auth-btn mt-4 mr-3" value="Elegir" runat="server" id="btnmayo" onserverclick="btnAuth1_ServerClick"/>
                    
                             
                      
                        <input type="button" class="auth-btn mt-4 ml-2 mr-3" value="Elegir" runat="server" id="btnbarba" onserverclick="btnAuth2_ServerClick"/>
                   
                             
                       
                        <input type="button" class="auth-btn mt-4 ml-2 mr-3" value="Elegir" runat="server" id="btnket" onserverclick="btnAuth3_ServerClick"/>



                <input type="button" class="auth-btn mt-4 ml-2 mr-2" value="Elegir" runat="server" id="btnsalsa" onserverclick="btnAuth4_ServerClick"/>



                <input type="button" class="auth-btn mt-4 ml-3" value="Elegir" runat="server" id="btnmozta" onserverclick="btnAuth5_ServerClick"/>
              
                   


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
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Nombre" runat="server" id="txtnombre" maxlength="30"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Apellido" runat="server" id="txtapellido" maxlength="30"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Direccion (Calle)" runat="server" id="txtdireccion" maxlength="30"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3"  style="width:230px" placeholder="Direccion (Numero)" runat="server" id="txtnumero" maxlength="5"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Localidad" runat="server" id="txtlocalidad" maxlength="30"/>                       
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Email" runat="server" id="txtemail" maxlength="30"/>
                        
                    </div>
                     <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" style="width:230px" placeholder="Telefono" runat="server" id="txttelefono" maxlength="15"/>
                        
                    </div>
                   
                    <div class="d-flex justify-content-center">
                        <input type="button" class="auth-btn mt-4 mr-5" value="Aceptar" runat="server" id="btnAceptarCliente" onserverclick="btnAceptarCliente_ServerClick"/>
                        <input type="button" class="auth-btn mt-4 ml-5" value="Cancelar" runat="server" id="btnCancelarCliente" onserverclick="btnCancelCliente_ServerClick"/>
                    </div>

                      <div class="d-flex justify-content-center">
                        <asp:label class="sub-header" runat="server" Visible="false" ID="lblfail"> DATOS INVALIDOS, VERIFIQUE LOS CAMPOS ANTES DE CONTINUAR </asp:label>
                    </div>
                    
                </div>
            </div>
        </div>
    </panel>




         <panel id="pnldni" runat="server" visible="false">
        <div class="header-container d-flex flex-direction-column">
            <label class="header">Sorteo</label>
            <label class="sub-header">Ingrese su DNI por favor</label>
        </div>
        <div class=" d-flex justify-content-center">
            <div class="d-flex flex-direction-column">
                
                <div class="input-container d-flex flex-direction-column">
                    <div class="d-flex justify-content-center">
                        <input type="text" class="input-text mb-3" placeholder="DNI" runat="server" id="txtdni" maxlength="10"/>
                        
                    </div>
                   
                   
                    <div class="d-flex justify-content-center">
                        <input type="button" class="auth-btn mt-4 mr-5" value="Aceptar" runat="server" id="btnAceptarDni" onserverclick="btnAceptarDni_ServerClick"/>
                        <input type="button" class="auth-btn mt-4 ml-5" value="Cancelar" runat="server" id="btnCancelarDni" onserverclick="btnCancelDni_ServerClick"/>
                    </div>
                      <div class="d-flex justify-content-center">
                        <asp:label class="sub-header" runat="server" Visible="false" ID="lblerrordni"> DNI INVALIDO, VERIFIQUE ANTES DE CONTINUAR </asp:label>
                    </div>
                    
                </div>
            </div>
        </div>
    </panel>


        
         <panel id="pnlend" runat="server" visible="false">
        <div class="header-container d-flex flex-direction-column">
            <label class="header">Muchas gracias por participar</label>
            <label class="sub-header">En caso de haber ganado se le avisara por el mail registrado</label>
        </div>
        
        </div>
    </panel>


    </body>














</asp:Content>
