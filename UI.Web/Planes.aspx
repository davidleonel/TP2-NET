<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.planes" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
        <asp:Label ID="ABMLabel" runat="server" Text="ABM Planes"></asp:Label>
        <br />
        <br />
       <asp:Panel ID="planesgridPanel" runat="server">
        <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
        <asp:GridView ID="planesgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Turquoise"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID plan" DataField="Id" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcionplan" />
                <asp:BoundField HeaderText="ID Especialidad" DataField="IdEspecialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    

       
    <asp:Panel ID="planPanel" Visible="false" runat="server">
        
        <asp:Label ID="idplanLabel" runat="server" Text="ID plan: "></asp:Label>
        <asp:TextBox ID="idplanTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
        <br />

        <asp:Label ID="descplanLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descplanTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descplanTextBox"
            ErrorMessage='La descripcion de la plan no puede estar vacia.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="idEspecialidadLabel" runat="server" Text="ID Especialidad: "></asp:Label>
        <asp:DropDownList ID="EspecialidadesDropDownList" runat="server" Width="153px">
        </asp:DropDownList>

   

    </asp:Panel>
        <br />
        <br />
   
       
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Volver a Menu</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

