   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TaskManager.ViewTaskManager.View  5      =#clr-namespace:TaskManager.ViewModelTaskManager.ViewModel  5      "    TaskManager.View.TaskManager   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TaskManager.View     5      :
viewModels#clr-namespace:TaskManager.ViewModel     5        � DataContext  5
      1   +TaskManager.ViewModel.TaskListTreeViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��400px �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��510 �6   �� 5      .+�5#   
   �� $��0��6   $��1��6%   $��30,30,30,166q�62   .+�5$      � .+�5%      R� -   5        $��treeView��5%      ��6+   �� *CategoryCollection+��5&      �� 5'       �� ItemsSource 63   �� *SubCategoryCollection+.R�5(      �� $��25(�6F   ��6(   �� *CategoryName+6F   5)      5+      5,      5-      �� 51   
   $��1��6   $��1��6%   $��30,30,30,30q�62   .+�52      &   System.Windows.Controls.DataGrid  -   5        $��DaGrid��54         AutoGenerateColumns .  $	��437��56   8     55      ��  �� ElementName$ treeView�� �� Path$ SelectedItem���56      �� *TaskCollection+   Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Task Name��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Y   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� *
TaskName+6Y     59      $ Priority��6)   $	 * 6\   
 6;   �� *TaskPriority+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5:      $ Task Deadline��6-   $	 * 6E      CellTemplate 5;      �� 5<      .R�5=   "   (  "System.Windows.Controls.DatePicker     Text 6-   �� *TaskDeadline+ �� StringFormat$ {0:dd/MM/yyyy}��5>      5@      4	  .System.Windows.Controls.DataGridCheckBoxColumn	  5A      $ Task Status��6-   $	 * 6b   
 6B   �� *IsCompleted+6b   5C      5D      �� 5H   
   $��1��6   $��2��6%   $��30,30,30,30q�62   .+�5I      �� $��16(�5J      $	��154��5L   2     5K      �� $ DaGrid��$ SelectedItem���5L      �� *TaskDescription+62   5M      o� 5Q   
   $��0��6   $��2��6   $��0��63   .@�5R      m� $
��File��6   .@�5U      m� $
��Open��6   m� 5V      -   5        $
��Save��5V      6)   m� 5W      $
��Exit��6   5X      m� 5Y      -   5        $��Category��5Y      .@�5Z      m� -   5        $	��New��5Z      6(   m� 5[      -   5        $��Change��5[      6+   m� 5\      -   5        $��Move Up��5\      6,   m� 5]      -   5        $��	Move Down��5]      6.   m� 5^      -	   5        $��Delete��5^      6+   5_      m� 5`      $
��View��6   .@�5b      m� -
   5        $��Search Task��5b      60   5c      m� 5d      $
��Help��6   .@�5e      m� $��About��6   5f      5g      5h      5i      