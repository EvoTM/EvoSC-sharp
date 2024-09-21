<component>
  <using namespace="System.Linq" />
  
  <import component="EvoSC.Containers.Window" as="Window" />
  <import component="EvoSC.Containers.Container" as="Container" />
  <import component="EvoSC.Style.UIStyle" as="UIStyle" />
  
  <import component="MatchManagerModule.Components.MatchSettingsListRow" as="MatchSettingsListRow" />
  
  <property type="IEnumerable<string>" name="availableMatchSettings" />
  <property type="double" name="winWidth" default="100" />
  <property type="double" name="winHeight" default="63" />
  
  <template>
    <UIStyle />
    
    <Window title="Match Settings" icon="{{ Icons.FileText }}" width="{{ winWidth }}" height="{{ winHeight }}">
      <Container 
              id="msList" 
              scrollable="true" 
              scrollHeight="{{ Math.Max(availableMatchSettings.Count()*10 - (winHeight-13), 0) }}" 
              width="{{ winWidth-5 }}" 
              height="{{ winHeight-11 }}"
      >
        <MatchSettingsListRow foreach="string name in availableMatchSettings" name="{{ name }}" width="{{ winWidth-5 }}" y="{{ -__index*10 }}" index="{{ __index }}" />
      </Container>
    </Window>
  </template>

  <script resource="EvoSC.Scripts.UIScripts" main="true" />
</component>
