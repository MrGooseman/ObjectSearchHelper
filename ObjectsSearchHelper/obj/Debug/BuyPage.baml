   M S B A M L   `   `   `  ����N  JObjectsSearchHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ObjectsSearchHelperObjectsSearchHelper  5      !    ObjectsSearchHelper.BuyPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ObjectsSearchHelper     5        N� Title$  BuyPage��5	       � DataContext 5
      (  "ObjectsSearchHelper.ClientsCBClass  5   
   -   5        CBViewModel��5      .��5      � ���#B7BEDA.+�5   
   �� -   5        $��
BackButton��5   )   $��50��6   $��50��6   
������ $��0q�6m    J� RenderTransformOrigin$ 
-3.44,-1.8&�6�   $��0,0,684,361q�6�   .��5      �� $��Resources/back_arrow.png��6   5      �� 5   
   -   5         ��Name$ 
SellerName��5   +   
������ $	��300��6?    �� TextWrapping$
 Wrap=�6K   $��16(�6_   $��183,76,317,344q�6m    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ RealtorName��5   +   
������ $��16(�6@   $	��300��6N    . $��183,146,317,279q�6m   �� 5   
   -   5         ��Name$ 
NextButton��5      $��Оплатить��6%   $��321,312,317,70q�68   ���#22AC47$��20(�6e   
���   �6�   �� 5   
   $	��100��6   $��30��6   $��Владелец: ��6(   $��16(�6=   $��83,76,617,344q�6K   �� 5   
   $	��100��6   $��30��6   $��Покупатель: ��6(   $��16(�6?   $��83,111,617,309q�6M   �� 5   
   $	��100��6   $��30��6   $��Риэлтор: ��6(   $��16(�6<   $��83,141,617,279q�6J   �� 5   
   -   5         ��Name$ BuyerBox��5      $	��200��6%   $��30��61   $��183,111,417,309q�6=    �� SelectedItem 6V   �� 	 �� Path$	 selectedClient�5      5      