   M S B A M L   `   `   `  ���� a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes   Interface_3fev   Interface_3fev.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Hei9http://schemas.microsoft.com/expression/2010/interactions       � AllowsTransparency  .  � WindowStyle$
 None=� � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=� � Title$ Lister��$	��320��$	��320��$	��515��$	��515�� � Icon$ Program-icon.ico�� � 	Resources    MyButtonStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime R� Value �� Color  Quitter  Minimise  Settings��%�  &	        &	 $    &	 F    &	 h    �� " ��.��� 	 � ��
 �� " ��.R�� $
 grid��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Panel.Background)�$
 grid��..�i� $ 0�� �� $ 	#FF1ABC9C��  Pressed��  Disabled��.+��� $��Center=�$��Center=��� " ��.��� 	 � ��
 �� " ��.R�� $
 grid��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Panel.Background)�$
 grid��..�i� $ 0�� �� $ #C0392B��  Pressed��  Disabled��.+��� $��Center=�$��Center=��� " ��.��� 	 � ��
 �� " ��.R�� $
 grid��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Panel.Background)�$
 grid��..�i� $ 0�� �� $ #2980b9��  Pressed��  Disabled��.+��� $��Center=�$��Center=��� " ��.��� 	 � ��
 �� " ��.R�� $
 grid��#��z��   CommonStates��.   
Normal��  	MouseOver��. �� .��T� $ (Panel.Background)�$
 grid��..�i� $ 0�� �� $ #7f8c8d��  Pressed��  Disabled��.+��� $��Center=�$��Center=�.��� -   $
 Grid�����	#FF2C3E50 � RowDefinitions �� $��21 ���  � ColumnDefinitions �� $
��257* ��� $
��258* �.+��� $
��Left=�$��10,5,0,0q�$
��Wrap=�$��Éditeur de Liste��$	��Top=�$	��224�����	#FFD85252$��16���� -    ��Name$ listBox��$��10q����	#FFBDC3C7$��1���� -    ��Name$ 
labelDebug��$
��Wrap=�$��Visualisation/Edition�����	#FFD84B51$��1��$��5,5,0,0q�$
��Left=�$	��177��$y�Hidden=��� -    ��Name$ 
buttomExit��#��[ $��X�� � ToolTip$ Quitter�����	#FFE74C3C$��Right=�$��21��$��21��$��60��$��38��$��1���� -   $ buttomMinimise��#��[ $��_��$ 	Minimiser�����#3498db$��Right=�$��21��$��21��$��60��$��38��$��0,0,38,0q�$��1���� -   $ buttomSettings��#��[ $ A propos�����#95a5a6$��Right=�$��21��$��21��$��60��$��38��$��0,0,76,0q�$��1��$��21��$	��Top=�.���� .+��� $��settings.png��$��Uniform=�$��20��� -   $ Grid2��$��1��$��2�� �� $
��104* ��� $	��25* � �� -    ��Name$ 
RemoveGrid��$	��13* ��� $��53 ��� $��6* �.+��� -	    ��Name$ texteboxDebug��$��
10,10,10,0q� �� TextWrapping$
 Wrap=����	#FF0F0F0F���	#FFBDC3C7$y�Hidden=�$��2��� $��1��$��0,45,0,0q�$��2��$��2�� �� $	��86* ��� $	��86* ��� $	��86* � �� $	��58* ��� $	��58* ��� $��5 �.+��� -
   $ Lire_Fichier��#��[  $��Lire Fichier��$��
10,10,10,1q�$A ;Remplace le contenue de la liste par celui du fichier json.�����#2ecc71���	#FF27AE60$��22��$��0���� -   $ Enlever��#��[  $��Enlever��$��
10,10,10,1q�$3 -Supprime la ligne selectionner dans la liste.�����#2ecc71���	#FF27AE60$��22��$��1���� -   $ Debug��#��[  $��Debug��$��
10,10,10,1q�$2 ,Permet de visualiser le contenue du tableau.�����#2ecc71���	#FF27AE60$��22��$��2���� -   $ Refresh��#��[  $��	Recharger��$��	10,5,10,8q�$) #Rafraichie le contenue de la liste.�����#2ecc71���	#FF27AE60$��22��$��1���� -   $ Ajouter��#��[  $��Ajouter��$��	10,4,10,8q�$% Ajoute une ligne dans la liste.�����#2ecc71���	#FF27AE60$��22��$��1��$��1���� -   $ Enregistrer��#��[  $��Enregistrer��$��	10,5,10,8q�$? 9Enregistre le contenue de la liste dans un fichier texte.�����#2ecc71���	#FF27AE60$��22��$��2��$��1��	� -    	�Name$ 	Ascendant��$��	Ascendant��$��
10,10,0,26q�
�������$&  Met en ordre croissant la liste.��$��1��$
��Left=�$	��100��	� -   $ 
Descendant��$��
Descendant��$
��Left=�$��	10,31,0,5q�
�������$( "Met en ordre decroissant la liste.��$	��100��$��1���� -   $ buttomTxt2Json��#���   $��Convertir Txt en Json��$��	0,4,10,26q����#2ecc71���	#FF27AE60$��22��$��22��$��1��$��Right=�$	��130��$y scharge un fichier separer avec des espaces et le converti en Json au format aproprier pour ce programme et le save.��$y�Hidden=�$��2���� -   $ buttomDebugSaveLoad��#��[  $��Enregistrer/Recharger��$��	0,30,10,0q����#2ecc71���	#FF27AE60$��22��$��22��$��1��$��Right=�$	��130��$y�Hidden=�$��2��