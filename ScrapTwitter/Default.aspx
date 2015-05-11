<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScrapTwitter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <asp:TextBox ID="txtquery" runat="server"></asp:TextBox>
        <asp:Button ID="btnquery" runat="server" Text="Button" OnClick="btnquery_Click" />
       

        <p>Account Holder:
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </p>
          <p>Following:<asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
         
          <p>Followers:   <asp:Label ID="Label5" runat="server" Text=""></asp:Label></p>
      
         <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
         <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
       
        <br />
       

       <h1>Followings</h1>


    </div>

    <div>
        <table class="table table-bordred table-striped">
            <thead>

                <th>Full Name
                </th>
                <th>Twitter Handle
                </th>
                <th>Followers
                </th>
                <th>Following</th>
            </thead>
            <tr>


                <td>
                     <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                   
                </td>

                <td>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
                <td> <asp:Label ID="follower" runat="server" ></asp:Label></td>

                <td> <asp:Label ID="following" runat="server" ></asp:Label></td>

                
            </tr>
        </table>

    </div>

</asp:Content>
