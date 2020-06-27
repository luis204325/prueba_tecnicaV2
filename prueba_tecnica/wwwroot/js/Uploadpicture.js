class Uploadpicture {
    archivo(evt, id) {
        let files = evt.target.files; //File liste object
        let f = files[0];
        if (f.type.match('image.*')) {
            let reader = new FileReader();
            reader.onload = ((theFile) => {
                return (e) => {
                    document.getElementById(id).innerHTML = ['<img class="imageUser" src="', e.target.result, '" tittle="', escape(theFile.name), '"/>'].join('');
                }
            })(f);
            reader.readAsDataURL(f);
        }
    }
} 