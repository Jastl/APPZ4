   M S B A M L   `   `   `  ����  FitnessClub.UI-    'FitnessClub.UI.Dialogs.MembershipDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Membership��5   	   $	��300��6   $	��400��6)    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Club:��6-   $��0,0,10,5q�6=   �� 5   
   -   5         ��Name$ clubComboBox��5   0   $��0��6   $��1��6     �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ Id��6,   $��0,0,0,5q�6C   �� 5   
   $��1��6   $��0��6   $��Start Date:��6-   $��0,0,10,5q�6C   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ startDatePicker��5   2   $��1��6   $��1��6"   $��0,0,0,5q�6K   �� 5   
   $��2��6   $��0��6   $��	End Date:��6-   $��0,0,10,5q�6A     5   
   -   5        $ endDatePicker��5   2   $��2��6   $��1��6"   $��0,0,0,5q�6I   �� 5   
   $��5��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5      $��Right=�6.   $��0,10,0,0q�6J   .+�5       �� -   5        $
��Save��5       $��80��6:   $��0,0,10,0q�6E   �� 5!      -   5        $��Cancel��5!      $��80��6>   5"      5#      5$      