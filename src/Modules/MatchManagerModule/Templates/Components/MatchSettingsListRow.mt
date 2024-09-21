<component>
  <import component="EvoSC.Controls.Panel" as="Panel" />
  <import component="EvoSC.Controls.IconButton" as="IconButton" />

  <property type="string" name="name" />
  <property type="double" name="width" />
  <property type="double" name="height" default="9" />
  <property type="double" name="y" />
  <property type="int" name="index" />

  <template>
    <Panel y="{{ y }}" width="{{ width }}" height="9" bgColor="{{ Theme.UI_BgHighlight }}">
      <label text="{{ name }}" class="text-xl text-primary" valign="center" pos="2 {{ -height/2 }}" />
      
      <IconButton 
              icon="{{ Icons.Trash }}" 
              id='{{ "btnDelete" + index }}' 
              x="{{ width-5-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialinkController/confirmDelete/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Pencil }}" 
              id='{{ "btnRename" + index }}' 
              x="{{ width-11-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialinkController/rename/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Copy }}" 
              id='{{ "btnDuplicate" + index }}' 
              x="{{ width-17-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialinkController/duplicate/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Play }}" 
              id='{{ "btnLoad" + index }}' 
              x="{{ width-23-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialinkController/load/{{ name }}"
      />
    </Panel>
  </template>

</component>
