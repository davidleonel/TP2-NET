<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
     <asp:Panel ID="usuarioPanel" Visible="true" runat="server">
        
        <asp:Label ID="usuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="usuarioTextBox" runat="server" Text="" ></asp:TextBox> 
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="usuarioTextBox"
            ErrorMessage='Debe completar con su nombre de usuario' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
         <asp:Label ID="noEncontradoLabel" runat="server" Text="Usuario  no Encontrado." Visible="False"></asp:Label>
        <br />


        <asp:Label ID="passLabel" runat="server" Text="Contraseña: "></asp:Label>
        <asp:TextBox ID="passTextBox" runat="server" Text="" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="passTextBox"
            ErrorMessage='Debe completar la contraseña.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
         <asp:Label ID="claveIncorrectaLabel" runat="server" Text="Clave Incorrecta!" Visible="false"></asp:Label>
         <br />
         <br />

         <asp:Button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click"/>
         <br />
         <asp:LinkButton ID="passOlvidadaHyperLink" runat="server">Olvidé mi clave</asp:LinkButton>

        <br />
    </asp:Panel>

    </div>

        </asp:Content>

