<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">






        <asp:HiddenField ID="editando" runat="server" />

    <asp:TextBox ID="txt_nombre" placeholder="Nombre" runat="server" ></asp:TextBox>
    <asp:TextBox ID="txt_apellido" placeholder="Apellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txt_edad" placeholder="Edad" runat="server"></asp:TextBox>
    <asp:Button ID="btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
    <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
    <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    <asp:GridView ID="GV_personas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource" 
        OnRowDeleting="GV_personas_RowDeleting" OnRowEditing="GV_personas_RowEditing" OnRowCancelingEdit="GV_personas_RowCancelingEdit" OnRowUpdating="GV_personas_RowUpdating" 
         OnSelectedIndexChanged="GV_personas_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
            <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger " />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>" SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>

    



</asp:Content>
