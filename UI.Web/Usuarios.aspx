﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

   <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" >Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" >Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" >Nuevo</asp:LinkButton>
    </asp:Panel>
        
      <asp:Panel ID="formPanel" Visible="false" runat="server">
        
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombreTextBox"
            ErrorMessage='El nombre no puede estar vacío' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="apellidoTextBox"
            ErrorMessage='El apellido no puede estar vacío' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="emailTextBox"
            ErrorMessage='El mail es inválido' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nombreUsuarioTextBox"
            ErrorMessage='El usuario no puede estar vacío' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="claveTextBox"
            ErrorMessage='La contraseña no puede estar vacía' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Dirección: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="repetirClaveTextBox"
            ErrorMessage='Las claves no coinciden' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
    </asp:Panel>

        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" >Cancelar</asp:LinkButton>
        </asp:Panel>

    </div>

        </asp:Content>
