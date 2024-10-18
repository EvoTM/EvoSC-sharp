<component>
  <using namespace="EvoSC.Common.Interfaces.Util" />
  <using namespace="EvoSC.Common.Util.MatchSettings.Models" />
  <using namespace="System.Linq" />
  
  <import component="EvoSC.Style.UIStyle" as="UIStyle" />
  <import component="EvoSC.Containers.Window" as="Window" />
  <import component="EvoSC.Containers.Container" as="Container" />
  <import component="EvoSC.Controls.Separator" as="Separator" />
  <import component="EvoSC.Controls.TextInput" as="TextInput" />
  <import component="EvoSC.Controls.Button" as="Button" />
  <import component="MatchManagerModule.Components.Editor.OptionRow" as="OptionRow" />

  <property type="IMatchSettings" name="matchSettings" />
  <property type="double" name="winWidth" default="100" />
  <property type="double" name="winHeight" default="70" />
  
  <template>
    <UIStyle />
    
    <Window title="Editing settings for '{{ matchSettings.Name }}'" icon="{{ Icons.Gears }}" width="{{ winWidth }}" height="{{ winHeight }}">
      <frame>
        <Container 
                id="settingsList" 
                scrollable="true" 
                scrollHeight="{{ 61 + matchSettings.ModeScriptSettings.Count()*6 }}" 
                width="{{ winWidth-5 }}" 
                height="{{ winHeight-20 }}" 
        >
          <frame>
            <label text="Game Information" class="text-xl" />
            <Separator length="{{ winWidth }}" x="0" y="-4" color="{{ Theme.UI_TextPrimary }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-6" index="0" name="gameMode" title="Game Mode" value="{{ matchSettings.GameInfos.GameMode }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-12" index="1" name="chatTime" title="Chat Time" value="{{ matchSettings.GameInfos.ChatTime }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-18" index="2" name="finishTimeout" title="Finish Timeout" value="{{ matchSettings.GameInfos.FinishTimeout }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-24" index="3" name="allWarmupDuration" title="All Warmup Duration" value="{{ matchSettings.GameInfos.AllWarmupDuration }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-30" index="4" name="disableRespawn" title="Disable Respawn" value="{{ matchSettings.GameInfos.DisableRespawn }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-36" index="5" name="forceShowAllOpponents" title="Force Show All Opponents"  value="{{ matchSettings.GameInfos.ForceShowAllOpponents }}"/>
            <OptionRow width="{{ winWidth-6 }}" y="-42" index="6" name="scriptName" title="Script Name" value="{{ matchSettings.GameInfos.ScriptName }}" />
          </frame>
  
          <frame pos="0 -50">
            <label text="Filter" class="text-xl" />
            <Separator length="{{ winWidth }}" x="0" y="-4" color="{{ Theme.UI_TextPrimary }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-6" index="7" name="isLan" title="Is Lan" value="{{ matchSettings.Filter.IsLan }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-12" index="8" name="isInternet" title="Is Internet" value="{{ matchSettings.Filter.IsInternet }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-18" index="9" name="isSolo" title="Is Solo" value="{{ matchSettings.Filter.IsSolo }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-24" index="10" name="isHotseat" title="Is Hotseat" value="{{ matchSettings.Filter.IsHotseat }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-30" index="11" name="sortIndex" title="Sort Index" value="{{ matchSettings.Filter.SortIndex }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-36" index="12" name="randomMapOrder" title="Random Map Order" value="{{ matchSettings.Filter.RandomMapOrder }}" />
          </frame>
          
          <frame pos="0 -92">
            <label text="Map Options" class="text-xl" />
            <Separator length="{{ winWidth }}" x="0" y="-4" color="{{ Theme.UI_TextPrimary }}" />
            <OptionRow width="{{ winWidth-6 }}" y="-6" index="13" name="startIndex" title="Start Index" value="{{ matchSettings.StartIndex }}" />
          </frame>
          
          <frame pos="0 -106">
            <label text="Script Settings" class="text-xl" />
            <Separator length="{{ winWidth }}" x="0" y="-4" color="{{ Theme.UI_TextPrimary }}" />
            <label if="matchSettings.ModeScriptSettings.Count() == 0" text="No settings set" class="text" pos="0 -6" />
            
            <OptionRow
                    foreach="(string name, ModeScriptSettingInfo option) in matchSettings.ModeScriptSettings"
                    index="{{ __index+14 }}"
                    name="{{ name }}"
                    title="{{ name }}"
                    value='{{ (option.Value ?? "").ToString() }}'
                    y="{{ -__index*6-6 }}"
                    width="{{ winWidth-6 }}"
            />
          </frame>
        </Container>
      </frame>
      
      <Button y="-(winHeight-19)" x="{{ winWidth-5-36 }}" id="btnCancel" text="Cancel" />
      <Button y="-(winHeight-19)" x="{{ winWidth-5-18 }}" id="btnSave" text="Save" action="EditMatchSettingsManialink/edit/{{ matchSettings.Name }}" />
    </Window>
  </template>

  <script resource="EvoSC.Scripts.UIScripts" main="true" />
</component>
