   M S B A M L   `   `   `  ����  FitnessClub.UI     FitnessClub.UI.VisitDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Register Visit��5   	   $	��300��6    $	��400��6-    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Client:��6-   $��0,0,10,5q�6?   �� 5   
   -   5         ��Name$ clientComboBox��5      $��0��5      $��1��6     �� DisplayMemberPath$ 	FirstName��5       �� SelectedValuePath$ Id��5      $��0,0,0,5q�5      �� 5   
   $��1��6   $��0��6   $��Membership:��6-   $��0,0,10,5q�6C   �� 5   
   -   5        $ membershipComboBox��5      $��1��5      $��1��6    $
 Type��5      $ Id��5      $��0,0,0,5q�5      �� 5!   
   $��3��6   $��2��6"    �� Orientation$ 
Horizontal=�5"      $��Right=�5#      .+�5$      �� -   5         ��Name$ btnSave��5$      $
��Save��6&   $��70��6K   $��0,0,10,0q�6V   �� 5%      -   5        $ 	btnCancel��5%      $��Cancel��6(   $��70��6Q   5&      5'      5(      