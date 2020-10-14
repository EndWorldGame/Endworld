import { Injectable } from "@angular/core";
import { CanActivate, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PartyService } from '../services/party.service';
import { Character } from '../character';


@Injectable({
    providedIn: 'root'
})
export class CharGuard implements CanActivate {

    constructor(private partyService: PartyService, private router: Router){}

    canActivate(): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        let party: Character[];
        this.partyService.getParty().subscribe(data => {
            party = data as Character[]
        })
        if (party.length > 0){
            return true;
        } else {
            this.router.navigate(['/auth']);
            return false;
        }
    }

}