<component>
  <using namespace="EvoSC.Common.Interfaces.Util" />

  <import component="EvoSC.Style.UIStyle" as="UIStyle" />
  <import component="EvoSC.Containers.Window" as="Window" />
  <import component="EvoSC.Controls.TextInput" as="TextInput" />

  <property type="string" name="name" />
  <property type="string" name="value" />
  <property type="int" name="index" />
  <property type="double" name="y" />
  <property type="double" name="width" />
  <property type="double" name="height" default="5" />

  <template>
    <frame>
      <label class="text-primary" text="{{ name }}" valign="center" pos="1 {{ -height/2 }}" />
      <TextInput id="txtValue-{{ index }}" y="{{ -(height - 5)/2 }}" x="{{ width-25-1 }}" />
    </frame>
  </template>

  <script resource="EvoSC.Scripts.UIScripts" main="true" />
</component>
