<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscripcionDocente.aspx.cs" Inherits="UI.Web.InscripcionDocente" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="InscripcionDocentegridPanel" runat="server">
            <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
        <asp:GridView ID="InscripcionDocentegridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Curso" DataField="Id" />
                <asp:BoundField HeaderText="ID Materia" DataField="IdMateria" />
                <asp:BoundField HeaderText="ID Comision" DataField="IdComision" />
                <asp:BoundField HeaderText="Anio Calendario" DataField="AnioCalendario" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
            <br />
            <asp:Label ID="cargoLabel" runat="server" Text="Cargo: "></asp:Label>
            <asp:DropDownList ID="CargoDropDownList" runat="server" Height="19px" Width="150px">
            </asp:DropDownList>
            <br />
    </asp:Panel>
      
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

