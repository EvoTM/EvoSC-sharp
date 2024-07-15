<component>
    <using namespace="GbxRemoteNet.Structs"/>
    
    <import component="EvoSC.Drawing.Rectangle" as="Rectangle"/>

    <property type="double" name="width" default="12.0"/>
    <property type="double" name="height" default="10.0"/>
    <property type="double" name="x" default="0.0"/>
    <property type="double" name="y" default="0.0"/>
    <property type="double" name="logoPadding" default="4.5"/>
    <property type="string" name="halign" default="left"/>
    <property type="TmTeamInfo" name="teamInfo"/>

    <template>
        <frame pos='{{ x - (halign=="right" ? width : 0) }} {{ y }}'>
            <Rectangle width="{{ width }}"
                       height="{{ height }}"
                       bgColor="{{ Theme.UI_HeaderBg }}ee"
                       cornerRadius="0.75"
                       corners='{{ (halign=="right" ? "BottomLeft" : "BottomRight") }}'
            />

            <quad if="!string.IsNullOrEmpty(teamInfo.EmblemUrl)"
                  pos="{{ width / 2.0 }} {{ height / -2.0 }}"
                  size="{{ width - logoPadding }} {{ height - logoPadding }}"
                  halign="center"
                  valign="center"
                  keepratio="Fit"
                  image="{{ teamInfo.EmblemUrl }}"
            />

            <label if="string.IsNullOrEmpty(teamInfo.EmblemUrl)"
                   pos="{{ width / 2.0 }} {{ height / -2.0 + 0.5 }}"
                   size="{{ width - logoPadding }} {{ height - logoPadding }}"
                   text="{{ teamInfo.Name }}"
                   textcolor="{{ Theme.UI_TextPrimary }}"
                   textfont="{{ Font.Bold }}"
                   textsize="{{ Theme.UI_FontSize * 2.0 }}"
                   halign="center"
                   valign="center"
            />
        </frame>
    </template>
</component>