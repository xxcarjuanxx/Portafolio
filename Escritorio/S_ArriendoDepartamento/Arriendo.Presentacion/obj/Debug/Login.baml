   M S B A M L   `   `   `  ����P  LArriendo.Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Arriendo.PresentacionArriendo.Presentacion  5   	   !    Arriendo.Presentacion.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Arriendo.Presentacion     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Login��5	   	   $	��500��6   $	��880��6'    � AllowsTransparency .   � WindowStyle$
 None=�6R    � WindowStartupLocation$ CenterScreen=�6e    � 
ResizeMode$ 	CanResize=�6   .��5
      � -   5         �Name$ gvLogin��5
       � ColumnDefinitions 5   
   �� 5      $	��280��6   $	��33* �6.   �� 5      $	��60* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��15* �6   �� 5      $	��15* �6   �� 5      $��5* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   .+�5    
   �� -   5        $��image1��5       $��0q�6   $
��Fill=�6+   $��1��6:   $��0��6N   $��9��6^   $��/img/fondo.png��5!      (� 5#   
   $��0��6   $��1��6"   .��5$      �� $��Login��6   $��Center=�6(   $��50��6E   $��	10 0 10 0q�6Q   $	��Top=�6d   $��80��6|   $��25(�6�   $
��Bold"�6�   $��0��6�   $��0��6�   5%      (� 5'      $��0��6   $��2��6&   .��5(      �� $7��1Bienvenido de nuevo. Inicia sesión con tu cuenta��6   $��Center=�6S   $��31��6p   $��14(�6|   $��	10 0 10 0q�6�   $	��Top=�6�   $
��Bold"�6�   $��0��6�   $��1��6�   5)      (� 5*      $��0��6   $��2��6&   .��5+      �� $��Label��6   $��Center=�6(   $��4��6E   $��
10,30,10,0q�6P   $	��Top=�6d   $��70��6|   ���	#FF454CC9$��0��6�   $��2��6�   5,      (� 5-   
   $��0��6   $��3��6"   .��5.      � $��Center=�6   $��40��61   $��	10 0 10 0q�6=   $	��Top=�6P   $	��233��6h   $��0��6t   $��3��6�   .+�5/      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��39��6Q   $��-1.333,0,0,0q�6]   $	��Top=�6s   $��234.5��6�   '  !MaterialDesignThemes.Wpf.PackIcon  50      	   Kind$	 Account=�6*   $��20��69   $��20��6D   $��Bottom=�6�   $	��0 0q�6�   ��6P   �� 
 �� ElementName$
 
txtUsuario�� �� Path$ BorderBrush�6�   �� 51      -   5         ��Name$ 
txtUsuario��51      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��6.    %  !MaterialDesignFloatingHintTextBox#��[  6X   $��25,0,0,0q�6�    �� 
CaretBrush �	#FF2B5BEB���	#FF696FD06�   52      53      (� 54   
   $��0��6   $��4��6"   .��55      � $��Center=�6   $��40��61   $��	10,0,10,0q�6=   $	��Top=�6P   $	��233��6h   .+�56      �� $ 
Horizontal=�6   $
��Left=�66   $��39��6Q   $��-1.333,0,0,0q�6]   $	��Top=�6s   $��234.5��6�   $��2��6�     57      $		 Key=�6*   $��20��65   $��20��6@   $��Bottom=�6�   $	��0 0q�6�   ��6L   �� $
 txtPassword��$ BorderBrush�6�   G� 58      -   5         G�Name$ txtPassword��58       $ Password��66    ) %MaterialDesignFloatingHintPasswordBox#��[ 6a   $��2��6�   $��25,0,0,0q�6�    G� 
CaretBrush �	#FF2B5BEB���	#FF696FD06�   59      5:      (� 5;   
   $��0��6   $��5��6"   .��5<      � -   5         �Name$ CircularProgress��5@   #    % !MaterialDesignCircularProgressBar#��[ 5=   #    � Value$ 0Q�5>   #    � IsIndeterminate . $��	10 0 10 0q�5@   >    J� RenderTransformOrigin$ 0.3,1.62&�6Q   $��Center=�5A   %   5B      (� 5C   
   $��0��6   $��6��6"   .��5D      �� -   5          MaterialDesignFlatButton#��[ 5E       � ToolTip$ Olvidaste tu contraseña��5F      $��	10 0 10 0q�67   $��31��6J   $!��¿Olvidaste tu contraseña?��6V   $��8(�6z   $
��Bold"�6�   $��Center=�6�   6�   5G      (� 5I   
   $��0��6   $��7��6"   .��5J      �� -   5         ��Name$ btnLogin��5J      $��Center=�6-   $ Iniciar sesión��5K   -   $��10 10 10 10q�6F   ���	#FF2B5BEB
������ $��Iniciar sesión��5L   G   6`   5N      �� 5_      $��/img/loginwpf2.png��6   $
��Fill=�60   $��1��6?   $��0��6O   $��9��6\   $��0q�6m   '  !MaterialDesignThemes.Wpf.Snackbar  5a   
   -	   5          Name$ SnackbarError��5e   !   $��0��5a   "   $��2��6/   $��180,0,180,0q�5b   "   $��Center=�5c   !      MessageF  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$   5d   !   ���	#FFCF4A56   IsActive .  $��2��5h   "   $y�Hidden=�66   5j      (� 5p   
   $��1��6   $��0��6"   $��Right=�6/   .��5q      d� -
   5         d�Name$ btn_Minimizar��5q       " MaterialDesignFlatToggleButton#��[ 5r      $ 	minimizar��5s      $��0 0 40 0q�6'   $��18��69   $��18��6E   $��1��6l   .��5t        $	 WindowMinimize=�5u      $��12��5v      $��17��5w      
���  ��6    5x      5{      (� 5|   
   $��2��6   $��0��6"   $��Right=�6/   .��5}   
   d� -   5        $ btn_Maximizar��5}      #��[ 5~      $ 	maximizar��5      $��0 0 20 0q�6'   $��18��69   $��18��6E   $��1��6l   .��5�        -   5          Name$ iconMaximizar��5�   &   $	 WindowMaximize=�5�      $��12��5�      $��20��5�      
���  ��6    5�      5�      (� 5�   
   $��2��6   $��0��6"   $��Right=�6/   .��5�      d� -   5        $ 	btn_Salir��5�      #��[ 5�      $ cerrar��5�      $��0 0 0 0q�6$   $��18��65   $��18��6A   $��1��6d   .��5�        $	 Close=�5�      $��12��5�      $��20��5�      
���  ��6    5�      5�      5�      5�      