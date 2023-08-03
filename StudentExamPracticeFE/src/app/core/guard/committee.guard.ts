import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/app/features/api-authorization/authorize.service';

@Injectable({
  providedIn: 'root'
})
export class CommitteeGuard {
  constructor(
    private authorizeService: AuthorizeService,
    private messageService: MessageService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authorizeService.hasRole('Committee').pipe(
      map(hasCommitteeRole => {
        if (hasCommitteeRole) {
          return true;
        } else {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Committee role is required for this operation.' });
          return false;
        }
      })
    );
  }

}
