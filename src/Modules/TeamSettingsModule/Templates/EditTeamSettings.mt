<component>
    <using namespace="EvoSC.Manialinks.Validation"/>
    <using namespace="EvoSC.Common.Interfaces.Localization"/>
    <using namespace="EvoSC.Modules.Official.TeamSettingsModule.Models"/>

    <import component="EvoSC.FormEntry" as="FormEntry"/>
    <import component="EvoSC.Containers.Window" as="Window"/>
    <import component="EvoSC.Style.UIStyle" as="UIStyle"/>
    <import component="EvoSC.Controls.Button" as="Button"/>

    <property type="FormValidationResult" name="Validation"/>
    <property type="TeamSettingsModel" name="Settings"/>
    <property type="dynamic" name="Locale"/>

    <template>
        <UIStyle/>

        <Window
                width="130"
                height="84"
                x="-65"
                y="44"
                title="{{ Locale.PlayerLanguage.UI_EditTeamInfo }}"
                icon=""
        >
            <!-- TEAM 1 -->
            <frame>
                <Label
                        text="{{ Locale.PlayerLanguage.UI_Team_One }}"
                        class="text-primary"
                        textsize="2"
                        halign="left"
                        valign="top"
                />
                
                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team1Name") }}'
                        name="Team1Name"
                        value="{{ Settings.Team1Name }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Name }}"
                        w="60"
                        y="-5"
                />
                
                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team1PrimaryColor") }}'
                        name="Team1PrimaryColor"
                        value="{{ Settings.Team1PrimaryColor }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Color_Primary }}"
                        w="60"
                        y="-20"
                />
                
                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team1SecondaryColor") }}'
                        name="Team1SecondaryColor"
                        value="{{ Settings.Team1SecondaryColor }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Color_Secondary }}"
                        w="60"
                        y="-35"
                />

                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team1EmblemUrl") }}'
                        name="Team1EmblemUrl"
                        value="{{ Settings.Team1EmblemUrl }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Emblem_URL }}"
                        w="60"
                        y="-50"
                />
            </frame>

            <!-- TEAM 2 -->
            <frame pos="65 0">
                <Label
                        text="{{ Locale.PlayerLanguage.UI_Team_Two }}"
                        class="text-primary"
                        textsize="2"
                        halign="left"
                        valign="top"
                />
                
                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team2Name") }}'
                        name="Team2Name"
                        value="{{ Settings.Team2Name }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Name }}"
                        w="60"
                        y="-5"
                />

                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team2PrimaryColor") }}'
                        name="Team2PrimaryColor"
                        value="{{ Settings.Team2PrimaryColor }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Color_Primary }}"
                        w="60"
                        y="-20"
                />

                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team2SecondaryColor") }}'
                        name="Team2SecondaryColor"
                        value="{{ Settings.Team2SecondaryColor }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Color_Secondary }}"
                        w="60"
                        y="-35"
                />

                <FormEntry
                        validationResults='{{ Validation?.GetResult("Team2EmblemUrl") }}'
                        name="Team2EmblemUrl"
                        value="{{ Settings.Team2EmblemUrl }}"
                        label="{{ Locale.PlayerLanguage.UI_Team_Emblem_URL }}"
                        w="60"
                        y="-50"
                />
            </frame>

            <frame pos="0 -65">
                <Button id="btnSubmit"
                        text="{{ Locale.PlayerLanguage.UI_Submit }}"
                        action="TeamSettings/SaveTeamSettings"
                />
                <Button id="btnCancel"
                        type="secondary"
                        text="{{ Locale.PlayerLanguage.UI_Cancel }}"
                        action="TeamSettings/HideTeamSettings"
                        x="106"
                />
            </frame>
        </Window>
    </template>

    <script resource="EvoSC.Scripts.UIScripts"/>
</component>