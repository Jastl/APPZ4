   M S B A M L   `   `   `  ����  FitnessClub.UI%    FitnessClub.UI.Pages.VisitsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Visits��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ btnRegisterVisit��5      $��Register Visit��6/   $��0,0,10,0q�6g   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   6;   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
visitsGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      $��10q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Client��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Z   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *Client.FirstName+6Z     5      $
 Club��6%   $	 * 6Q   
 63   �� *	Club.Name+6Q     5      $ 
Membership��6%   $	 * 6]   
 69   �� *Membership.Type+6]     5      $ 
Visit Time��6%   $	 * 6W   
 69   �� *	VisitTime+6W   5      5      5      