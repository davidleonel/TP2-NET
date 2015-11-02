<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="CursosgridPanel" runat="server">
        <asp:GridView ID="CursosgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Curso" DataField="Id" />
                <asp:BoundField HeaderText="ID Materia" DataField="IdMateria" />
                <asp:BoundField HeaderText="ID Comision" DataField="IdComision" />
                <asp:BoundField HeaderText="Anio Calendario" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    

       
    <asp:Panel ID="CursoPanel" Visible="false" runat="server">
        
        <asp:Label ID="idCursoLabel" runat="server" Text="ID Curso: "></asp:Label>
        <asp:TextBox ID="idCursoTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
        <br />

        <asp:Label ID="idMateriaLabel" runat="server" Text="ID Materia: "></asp:Label>
        <asp:DropDownList ID="MateriaDropDownList" runat="server" Height="17px" Width="165px">
        </asp:DropDownList>
        
        <asp:Label ID="idComisionLabel" runat="server" Text="ID Comision: "></asp:Label>
        <asp:DropDownList ID="ComisionDropDownList" runat="server" Width="165px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="idComisionTextBox"
            ErrorMessage='El ID de la Comision no puede estar vacio.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="anioCalendarioLabel" runat="server" Text="Anio Calendario: "></asp:Label>
        <asp:TextBox ID="anioCalendarioTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="anioCalendarioTextBox"
            ErrorMessage='Las horas totales no pueden ser nulas.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server" Text=""></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cupoTextBox"
            ErrorMessage='Las horas totales no pueden ser nulas.' EnableClientScript="true" SetFocusOnError="true"
            Text="*"></asp:RequiredFieldValidator>
        <br />

   

    </asp:Panel>

   
       
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

