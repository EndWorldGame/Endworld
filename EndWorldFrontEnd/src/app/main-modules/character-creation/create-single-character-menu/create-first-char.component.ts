import { Component, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { CharClass } from '../../../common/char-class';
import { NgForm } from '@angular/forms';
import { CharRace } from '../../../common/char-race';
import { Character } from 'src/app/common/character';
import { PartyService } from 'src/app/common/services/party.service';
import { CharClassService } from 'src/app/common/services/char-class.service';
import { CharRaceService } from 'src/app/common/services/char-race.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './create-first-char.component.html',
    styleUrls: ['./create-first-char.component.css']
  })
  export class CreateFirstCharComponent {
      
    character: Character;
    charClasses: CharClass[] = [];
    charRaces: CharRace[] = [];

    constructor(private charClassService: CharClassService, private charRaceService: CharRaceService,
        private partyService: PartyService, private router: Router){

    }

    ngOnInit(){
      this.charClassService.getCharClasses().subscribe(data => this.charClasses = data);
      this.charRaceService.getCharRaces().subscribe(data => this.charRaces = data);
    }

    updateCharacterPreview(formModel){
      if(formModel.charClass && formModel.charRace){
        this.character = this.generateChar(formModel);
      }
    }

    generateChar(formModel){
      let charClass: CharClass;
      let charRace: CharRace;
      this.charClassService.getCharClassByName(formModel.charClass).subscribe(data => charClass = data);
      this.charRaceService.getCharRaceByName(formModel.charRace).subscribe(data => charRace = data);
      return new Character(
          formModel.charName || '',
          charClass,
          charRace,
          charClass.defaultWeapon,
          charClass.defaultArmor
        )
    }

    validCharacter(): boolean {
      return (!!this.character && this.character.name.length > 0)
    }

    createCharacter(){
      if (this.partyService.getPartySize() < 3){
        this.partyService.addCharacter(this.character);
      }
      this.router.navigate(['']);
    }

  }