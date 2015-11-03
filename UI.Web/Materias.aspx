<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="MateriasgridPanel" runat="server">
        <asp:GridView ID="MateriasgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Materia" DataField="Id" />
                <asp:BoundField HeaderText="Descripcion" DataField="DescripcionMateria" />
                <asp:BoundField HeaderText="Horas Semanales" DataField="HsSemanales" />
                <asp:BoundField HeaderText="Horas Totales" DataField="HsTotales" />
                <asp:BoundField HeaderText="ID Plan" DataField="IdPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    

       
    <asp:Panel ID="MateriaPanel" Visible="false" runat="server">
        
        <asp:Label ID="idMateriaLabel" runat="server" Text="ID Materia: "></asp:Label>
        <asp:TextBox ID="idMateriaTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
        <br />

        <asp:Label ID="descMateriaLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descMateriaTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="descMateriaTextBox"
            ErrorMessage='La descripcion de la materia no puede estar vacia.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Hs. Semanales: "></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="hsSemanalesTextBox"
            ErrorMessage='Las horas semanales no pueden ser nulas.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsTotalesLabel" runat="server" Text="Hs. Totales: "></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="hsTotalesTextBox"
            ErrorMessage='Las horas totales no pueden ser nulas.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idPlanLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="PlanesDropDownList" runat="server" Width="153px">
        </asp:DropDownList>

   

    </asp:Panel>

   
       
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

