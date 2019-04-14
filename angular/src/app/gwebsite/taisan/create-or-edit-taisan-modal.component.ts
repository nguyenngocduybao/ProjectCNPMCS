import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TaiSanServiceProxy, TaiSanInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditTaiSanModal',
    templateUrl: './create-or-edit-taisan-modal.component.html'
})
export class CreateOrEditTaiSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('taiSanCombobox') taiSanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    taiSan: TaiSanInput = new TaiSanInput();

    constructor(
        injector: Injector,
        private _taiSanService: TaiSanServiceProxy
    ) {
        super(injector);
    }

    show(taiSanId?: number | null | undefined): void {
        this.saving = false;


        this._taiSanService.getTaiSanForEdit(taiSanId).subscribe(result => {
            this.taiSan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.taiSan;
        this.saving = true;
        this._taiSanService.createOrEditTaiSan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
