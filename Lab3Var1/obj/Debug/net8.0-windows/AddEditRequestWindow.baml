   M S B A M L   `   `   `  ����  Lab3Var10    *TechnicRepairVar2Lab3.AddEditRequestWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$>  8Добавить/Редактировать заявку��5   	   $	��460��6/   $	��350��6<   .��5      �� $��10q�6   .+�5   
   �� $��Тип машины:��6   �� 5   
   -   5         ��Name$ CarTypeComboBox��5      $	��200��5
      ��5   ,   �� *
CarTypes+ �� SelectedItem 5	      �� *Request.CarType+ �� Mode$ TwoWay=�5
      �� 5   
   $ ��Модель машины:��6   �� 5   
   -   5         ��Name$ TechnicModelTextBox��5      $	��200��6b   ��6/   �� *Request.TechnicModel+$ TwoWay=�6b   �� 5   
   $(��"Описание проблемы:��6   �� 5   
   $	��200��6D   ��6   �� *Request.Description+$ TwoWay=�6D   �� 5   
   $��Клиент (ФИО):��6   �� 5   
   -   5        $ ClientLFPTextBox��5      $	��200��6\   ��6,   �� *Request.ClientLFP+$ TwoWay=�6\   �� 5   
   $$��Телефон клиента:��6   �� 5   
   -   5        $ PhoneNumberTextBox��5      $	��200��6`   ��6.   �� *Request.PhoneNumber+$ TwoWay=�6`   �� 5   
   $ ��Статус заявки:��6   �� 5   
   $	��200��5      ��5      �� *RequestStatuses+ 5      �� *Request.Status+$ TwoWay=�5      �� 5   
   $$��Этап выполнения:��6   �� 5   
   $	��200��5       ��5      �� *ExecutionStages+ 5      �� *Request.ExStage+$ TwoWay=�5       �� 5"   
   $0��*Ответственный механик:��6   �� 5#   
    �� DisplayMemberPath$	 LFP��5$      $	��200��5&      ��5#      �� *	Mechanics+ 5%      �� *SelectedMechanic+$ TwoWay=�5&      �� 5(   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��10q�6J   .+�5)      �� -   5        $��Сохранить��5)      $	��100��6<   $��5q�6H   �� 5*      -   5        $��Отмена��5*      $	��100��6;   $��5q�6G   5+      5-      5.      