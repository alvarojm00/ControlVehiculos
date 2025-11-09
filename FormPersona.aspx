<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">






    <asp:HiddenField ID="editando" runat="server" />

    <div class="Container d-flex flex-column mb-3 gap-2">

        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Apellido1" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Apellido2" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtfechaNacimiento" TextMode="Date" CssClass="form-control" placeholder="FechaNacimiento" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" runat="server"></asp:TextBox>

        <asp:Button ID="btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
        <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    </div>

    <asp:GridView ID="GV_personas" runat="server" AutoGenerateColumns="False" DataKeyNames="idPersona" DataSourceID="SqlDataSource"
        CssClass="table table-striped table-hover table-success"
        OnRowDeleting="GV_personas_RowDeleting" OnRowEditing="GV_personas_RowEditing" OnRowCancelingEdit="GV_personas_RowCancelingEdit" OnRowUpdating="GV_personas_RowUpdating"
        OnSelectedIndexChanged="GV_personas_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="idPersona" HeaderText="ID" SortExpression="idPersona" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" SortExpression="Apellido1" />
            <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" SortExpression="Apellido2" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimientoo" SortExpression="FechaNacimiento" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger " />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>"
        SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>





</asp:Content>
