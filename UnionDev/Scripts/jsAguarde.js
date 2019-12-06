//Loading para todas as telas
var msgLoad = (function ($) {



    // Criar div com modal do materialize
    var $janela = $(
        '<div id="modalTeste" class="modal">' +
            '<div class="modal-content">' +
                     '<div class="preloader-wrapper big active">' +
                        '<div class="spinner-layer spinner-blue-only">' +
                             '<div class="circle-clipper left">' +
                                 '<div class="circle"></div>' +
                              '</div>'+
                              '<div class="gap-patch"> ' +
                                   '<div class="circle"></div>' +
                              '</div>' +
                              '<div class="circle-clipper right">' +
                                    '<div class="circle"></div>' +
                              '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
            '</div>' 
        );

    

    return {

        //Funçao abrir
         abrir: function () {
            //Abrir modal
            
            $janela.modal();
            $janela.modal('open');

        },

        //Funçao de fechar
        fechar: function () {
            $janela.modal('close');
        }

    }

})(jQuery);