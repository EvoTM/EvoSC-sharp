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
              action="MatchSettingsManialink/confirmDelete/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Pencil }}" 
              id='{{ "btnRename" + index }}' 
              x="{{ width-11-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialink/rename/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Copy }}" 
              id='{{ "btnDuplicate" + index }}' 
              x="{{ width-17-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialink/duplicate/{{ name }}"
      />

      <IconButton
              icon="{{ Icons.Gears }}"
              id='{{ "btnEdit" + index }}'
              x="{{ width-23-2 }}"
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialink/edit/{{ name }}"
      />

      <IconButton
              icon="{{ Icons.ListUl }}"
              id='{{ "btnMaps" + index }}'
              x="{{ width-29-2 }}"
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialink/editMaps/{{ name }}"
      />
      
      <IconButton 
              icon="{{ Icons.Play }}" 
              id='{{ "btnLoad" + index }}' 
              x="{{ width-35-2 }}" 
              y="{{ -(height-5)/2 }}"
              action="MatchSettingsManialink/load/{{ name }}"
      />
    </Panel>
  </template>
</component>
