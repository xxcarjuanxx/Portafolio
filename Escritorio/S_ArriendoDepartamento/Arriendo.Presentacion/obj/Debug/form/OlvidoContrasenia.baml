   M S B A M L   `   `   `  ����P  LArriendo.Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Arriendo.Presentacion.formArriendo.Presentacion.form  5   	   2    ,Arriendo.Presentacion.form.OlvidoContrasenia   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Arriendo.Presentacion.form     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          � Title$  OlvidoContrasenia��5	   	   $	��300��6#   $	��600��60    � AllowsTransparency .  � WindowStyle$
 None=�6V    � WindowStartupLocation$ CenterScreen=�6i   .��5
      � $��
0,0,-0.4,0q�6   .+�5   
   �� $!��¿Olvidaste tu contraseña?��6   $��Center=�64   $��44��6Q   $��
10,23,10,0q�6]   $	��Top=�6q   $	��310��6�   $��25(�6�   $
��Bold"�6�   �� 5   
   $(��"Bienvenido de nuevo. Digite su rut��6   $��Center=�6=   $��41��6Z   $��
10,67,10,0q�6f   $	��Top=�6z   $	��255��6�   $
��Bold"�6�   $��15(�6�   �� 5   
   $��Label��6   $��Center=�6    $��5��6=   $��10,108,10,0q�6H   $	��Top=�6]   $��55(�6u   $��70��6�   ���	#FF454CC96�   � 5   
   $
��Left=�6   $��50��6+   $��175,132,0,0q�67   $	��Top=�6L   $	��233��6d   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��39��6M   $��-1.333,0,0,0q�6Y   $	��Top=�6o   $��234.5��6�   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ Account=�6&   $��35��65   $��35��6@   $��Bottom=�5   &   $	��0 0q�6A   ��5   L   ��  �� ElementName$ 
txtUsuario�� �� Path$ BorderBrush�5   Q   �� 5      -   5         ��Name$ 
txtUsuario��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Usuario��6*    %  !MaterialDesignFloatingHintTextBox#��[  6T   $��40,0,0,0q�6�   
 �� 
CaretBrush
 �	#FF2B5BEB���	#FF696FD0$��15(�5   t   5      � 5   
   -   5         �Name$ CircularProgress��5       % !MaterialDesignCircularProgressBar#��[ 5       � Value$ 0Q�5       � IsIndeterminate . $��290,195,283.4,72q�5   (    J� RenderTransformOrigin$ 0.3,1.62&�5      $��Center=�5      $
��Auto��6*   $��27��68   �� 5    
   -   5         ��Name$ btnOlvidoContrasenia��5       $��Center=�65   $��17(�6R    � ToolTip$ Enviar��5!      ���	#FF2B5BEB
������ $��Enviar��6P   $��10,199,10,0q�6y   $	��150��6�   '  !MaterialDesignThemes.Wpf.Snackbar  5$   
   -   5          Name$ SnackbarError��5(   !   $��0��5$   "   $��1��6/   $��2��6?   $��180,0,180,0q�5%   "   $��Stretch=�5&   !   $	��Top=�6?      MessageF  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$   5'   !   ���	#FFCF4A56   IsActive .  $y�Hidden=�5*   3   $��6��5+   "   5-        5/   
   -   5        $ SnackbarCorrecto��53   !   $��180,0,180,0q�50   "   $��Stretch=�51   !   $	��Top=�6@   $ asdfgh 52   !   ���	#FF3AB74B .  $y�Hidden=�55   4   58      d� 5;   
   -   5         d�Name$ 	btn_Salir��5;       " MaterialDesignFlatToggleButton#��[ 5<      $ cerrar��5=      $��575,0,0.4,280q�6   $
��Auto��6+   $
��Auto��69   .��5>        $ Close=�5?      $��25��5@      $��22��5A      
���  ��6   5B      5F      5I      