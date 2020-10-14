import { Component } from '@angular/core';
import { ThrowStmt } from '@angular/compiler';
import { Router } from '@angular/router';
import { Character } from './common/character';
import { PartyService } from './common/services/party.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  party: Character[];
  constructor(private router: Router, private partyService: PartyService){ }
  
  ngOnInit(){
    this.partyService.getParty().subscribe(data => {
      this.party = data;
    })
  }

  roll(x){
    return Math.floor(Math.random() * x) + 1;
  }
}
