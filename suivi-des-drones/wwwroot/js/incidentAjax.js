// de l'ajax
class IncidentService {
    async loadAll() {
        //const url = '@linkeGenerator.GetPathByPage(this.HttpContext,"Incident")';
        //const at = '@linkeGenerator.GetUriByAction(this.HttpContext,action:"Index",controller:"Incident")';
        const urlApi = '/api/incident/index';
        const response = await fetch(urlApi);
        const data = await response.json();

        return data;
    }
}

const container = document.querySelector("#incident");
const timer = 1000;

setInterval(async () => {
    let html = '';
    const data = await (new IncidentService()).loadAll();

    data.forEach(incident => {
        //console.log(incident);
        //let row = `<span><i>NumAccident ${incident.id} - Drone : ${incident.idDrone} - Date : ${incident.dateIncident} </i></span> <br>`;
        const dateAc = new Date(incident.dateIncident);
        let row = `<tr><td>${incident.id}</td><td>${incident.idDrone}</td><td>${dateAc.toLocaleDateString('fr-FR')}</td><td>${incident.raison}</td></tr>`;
        html += row;
    });
    container.innerHTML = html;
}, timer);