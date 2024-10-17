<!--
A solid line used for a visual separation of different sections
of the user interface.
-->
<component>
  <!-- X position of the separator -->
  <property type="double" name="x" default="0" />

  <!-- Y position of the separator -->
  <property type="double" name="y" default="0" />

  <!-- Length of the separator line -->
  <property type="double" name="length" default="10" />

  <!-- Thickness of the separator line -->
  <property type="double" name="thickness" default="0.5" />
  
  <!-- The direction of the separator, can be: horizontal or vertical -->
  <property type="string" name="direction" default="horizontal" /> <!-- horizontal or vertical -->
  
  <!-- Color of the separator line -->
  <property type="string?" name="color" default="" />
  
  <template>
    <quad 
            pos="{{ x }} {{ y }}" 
            size="{{ length }} {{ thickness }}" 
            bgcolor="{{ string.IsNullOrEmpty(color) ? Theme.UI_Separator_Default_Bg : color }}"
            if='direction == "horizontal"'
    />

    <quad
            pos="{{ x }} {{ y }}"
            size="{{ thickness }} {{ length }}"
            bgcolor="{{ string.IsNullOrEmpty(color) ? Theme.UI_Separator_Default_Bg : color }}"
            if='direction == "vertical"'
    />
  </template>
</component>
