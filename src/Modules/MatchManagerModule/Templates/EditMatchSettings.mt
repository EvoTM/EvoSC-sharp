<component>
  <using namespace="EvoSC.Common.Interfaces.Util" />
  <using namespace="EvoSC.Common.Util.MatchSettings.Models" />
  <using namespace="System.Linq" />
  
  <import component="EvoSC.Style.UIStyle" as="UIStyle" />
  <import component="EvoSC.Containers.Window" as="Window" />
  <import component="MatchManagerModule.Components.Editor.OptionRow" as="OptionRow" />

  <property type="IMatchSettings" name="matchSettings" />
  <property type="double" name="winWidth" default="100" />
  <property type="double" name="winHeight" default="63" />
  
  <template>
    <UIStyle />
    
    <Window title="Editing settings for '{{ matchSettings.Name }}'" icon="{{ Icons.Gears }}" width="{{ winWidth }}" height="{{ winHeight }}">
      <label text="{{ matchSettings.ModeScriptSettings.Count() }}" />
      <OptionRow foreach="KeyValuePair<string, ModeScriptSettingInfo> kv in matchSettings.ModeScriptSettings" name="S_TimeLimit" value="300" index="0" y="{{ -__index*6 }}" width="55" />
    </Window>
  </template>

  <script resource="EvoSC.Scripts.UIScripts" main="true" />
</component>
