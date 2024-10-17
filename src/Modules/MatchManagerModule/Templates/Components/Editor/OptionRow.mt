<component>
  <using namespace="EvoSC.Common.Interfaces.Util" />

  <import component="EvoSC.Style.UIStyle" as="UIStyle" />
  <import component="EvoSC.Containers.Window" as="Window" />
  <import component="EvoSC.Controls.TextInput" as="TextInput" />

  <property type="string" name="name" />
  <property type="string" name="title" />
  <property type="string" name="description" default="" />
  <property type="int" name="index" />
  <property type="double" name="y" />
  <property type="double" name="width" />
  <property type="string" name="value" default="" />
  <property type="double" name="height" default="5" />
  <property type="double" name="textFieldWidth" default="45" />

  <template>
    <frame pos="0 {{ y }}">
      <label class="text-primary" text="{{ title }}" valign="center" pos="1 {{ -height/2 }}" />
      <TextInput width="textFieldWidth" id="txtValue-{{ index }}" y="{{ -(height - 5)/2 }}" x="{{ width-textFieldWidth-1 }}" value="{{ value }}" />
    </frame>
  </template>
</component>
