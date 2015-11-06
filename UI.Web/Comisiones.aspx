<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="ComisionesgridPanel" runat="server">
           <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
        <asp:GridView ID="ComisionesgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Comision" DataField="Id" />
                <asp:BoundField HeaderText="Descripcion" DataField="DescripcionComision" />
                <asp:BoundField HeaderText="Año " DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="IdPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    

       
    <asp:Panel ID="ComisionPanel" Visible="false" runat="server">
        
        <asp:Label ID="idComisionLabel" runat="server" Text="ID Comision: "></asp:Label>
        <asp:TextBox ID="idComisionTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
        <br />

        <asp:Label ID="descComisionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descComisionTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descComisionTextBox"
            ErrorMessage='La descripcion de la comision no puede estar vacia.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="anioLabel" runat="server" Text="Año: "></asp:Label>
        <asp:TextBox ID="anioTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="anioTextBox"
            ErrorMessage='el año no pueden estar vacío.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idPlanLabel" runat="server" Text="ID Plan: "></asp:Label>
        <asp:DropDownList ID="PlanesDropDownList" runat="server" Width="153px">
        </asp:DropDownList>

    </asp:Panel>


    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

