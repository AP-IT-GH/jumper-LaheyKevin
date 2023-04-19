# ML Agents Deel 3: Jumper exercise
Kevin Lahey, Quinten moons - 2ITIOT

## Uitleg

Het project bestaat uit de agent en 2 beweegbare balken. Deze balken komen vanuit 2 richtingen op de agent af (x, z). De bedoeling is dat de agent deze balken ontwijkt door te springen. De agent is geplaats in het midden van een kruispunt.

## Opbouw

De 2 obstakels maken gebruik van een script dat ze laat bewegen in de richting x en z. In de start functie wordt de startlocatie van het obstakel geplaats en een willekeurige snelheid bepaald. In de update functie wordt het obstakel verplaats over zijn as (x, z). Als een obstakel het punt 10 bereikt zal deze de start functie aanroepen. Doordat er 2 obstakels zijn, zijn er ook 2 obstakel scripts (x en z script).

We hebben de kubus een "Ray Perception Sensor 3D" gegeven zodat deze rond zich kan kijken. De kubus zal beloond worden wanneer hij over een balk heen springt. We hebben toegevoegd dat als hij sprint zonder dat dit nodig is er een afstraffing gebeurd. Ook als hij van het platform zou vallen gebeurd er een afstraffing. Om te weten of de kubus over een obstakel is gesprongen maken we gebruik van een raycast. Die naar de onderkant van de cubus kijkt en controleerd of hier een object met tag obstacle voorbijkomt. Als dit het geval is wordt de agent beloond.

Als de agent de obstakels aanraakt zal er ook een afstraffing gebeuren en de episode opniuew beginnen.

## Training

Op de grafiek is te zien dat er de eerste 100K geen grote sucsessen zijn geboekt. Na de 100K is het linear naar boven gegaan. Hierna hebben de waardes veel geschommelt.

Het eindresultaat is een agent die de obstakels ziet aankomen en optijd springt. Hij springt ook niet zonder dat er een obstakel aankomt.

!(Tensorboard foto)[https://github.com/AP-IT-GH/jumper-LaheyKevin/blob/main/Tensorboard.jpg]

## Links
(Link Github)[https://github.com/AP-IT-GH/jumper-LaheyKevin]

(Link Panopto)[https://ap.cloud.panopto.eu/Panopto/Pages/Viewer.aspx?id=bfffbd76-5de7-459e-b27b-afe90130b675]