<component>
    <import component="EvoSC.Theme" as="Theme" />
    <import component="EvoSC.Window" as="Window" />
    <import component="EvoSC.Controls.Button" as="Button" />
    
    <using namespace="ManiaExchange.ApiClient.Api.Models" />
    
    <property type="TmxMappackInfo" name="info" />
    <property type="TmxMappackMapInfo[]" name="maps" />
    
    <template>
        <Theme/>
        <Window id="mapInfo" title="{{ info.Name }}" >
            <Label text="{{ info.Name }} {{ info.TrackCount }}" />
            <Frame y="-5">
                <Label foreach="TmxMappackMapInfo mapInfo in maps" y="{{ -3 * __index }}" text="{{ mapInfo.Name }}"/>
            </Frame>
            <Button x="30" y="-20" id="button_add" text="Add"/>
        </Window>
    </template>

    <script>
        <!--
        *** OnMouseClick ***
        ***
        if (Event.Control.ControlId == "button_add") {
            TriggerPageAction("TmxManialinkController/AddMapPack/{{ info.ID }}");
            CloseWindow("mapInfo");
        }
        ***
        -->
    </script>

    <script resource="EvoSC.Scripts.UIScripts" />
</component>