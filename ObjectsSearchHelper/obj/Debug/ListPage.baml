   M S B A M L   `   `   `  ����N  JObjectsSearchHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ObjectsSearchHelperObjectsSearchHelper  5      "    ObjectsSearchHelper.ListPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ObjectsSearchHelper     5        N� Title$  ListPage��5	       � DataContext 5      #  ObjectsSearchHelper.ListClass  5   
   -   5        ListBoxViewModel��5       � 	Resources 5       �� 
TargetType   CornerTemplate �� CornerRadius��%�   &	        �� 5   
   " ��6   .R�5      �� $ 20��6   #��z��5      #��z��5      #��z��5      #��z��5      #��z��5      ._�5      �� #��z��6!   #��z��5   !   #��z��5   !   #��z��5   !   5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ 
ListOfData��5   %   
�������  ListDataTemplate#���  6�    �� SelectedItem 6V   ��  �� ElementName$ ListBoxViewModel�� �� Path$ selectedItem� 5      	 � ColumnDefinitions
 � RowDefinitions��%?  &	       �� 5       .R�5!      � ���#E4E4E4$	��744��60   	 5"      �� 5#      $��2* �6/   �� 5$      $��2 �6/   �� 5%      $��4* �6/   �� 5&      $��2 �6/   �� 5'      $��4* �6/   .+�5)      �� $	��100��6    $	��100��6-   $��10q�6:   ��6F   �� *image+� 5*      $��4��6   
 5+      �� 5,   "   �� 5-   "   .+�5/      �� 
������ $��18(�6A   $��Center=�6O   $	��Top=�6l   $��Цена (руб.)��6�   �� 50      
������ $��1��6A   $
��Wrap=�6N   $��18(�6y   $��Center=�6�   $	��Top=�6�   ��6b   �� *price+6�   51      �� 52      
������ $��2��6=   $
��Wrap=�6M   $��18(�6~   $	��Top=�6�   ��6a   �� *description+6�   �� 53      
���   �$��1��67   �� 54      
���   �$��3��67   55      56      57      58      59      5:      