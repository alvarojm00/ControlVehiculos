<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="ControlVehiculos.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div class="card p-4 shadow-sm">

        <h2>Registro de Usuario</h2>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Label ID="LabelEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>


        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"  ></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblConfirmarPassword" runat="server" Text="Confirmar Contraseña:"></asp:Label>
            <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Button ID="btnregistrar" runat="server" Text="Registrar" OnClick="btnregistrar_Click" CssClass="btn btn-primary mt-2" />
    </div>
 
 
</asp:Content>






