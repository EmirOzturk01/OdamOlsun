
document.addEventListener("DOMContentLoaded", function () {
    const ilSelect = document.getElementById('il');
    const ilceSelect = document.getElementById('ilce');
    const semtSelect = document.getElementById('semt');

    let selectedCityId = ilSelect.getAttribute('data-selected-il');
    let selectedIlce = ilceSelect.getAttribute('data-selected-ilce');
    let selectedSemt = semtSelect.getAttribute('data-selected-semt');

    // İllerin JSON verisinden çekilmesi
    fetch('https://api.kadircolak.com/Konum/JSON/API/ShowAllCity')
        .then(response => response.json())
        .then(data => {
            data.forEach(il => {
                const option = document.createElement('option');
                option.value = il.ID;
                option.text = il.TEXT;
                ilSelect.appendChild(option);
                
            });
            console.log('ilIlceSemt işlemi tamamlandı.'); // Debug mesajı
            window.dispatchEvent(new Event('ilIlceSemtComplete'));

            // Seçili ili yerleştirme
            ilSelect.value = selectedCityId || ''; // Varsayılan olarak 'Şehir Seçiniz' seçeneği ayarlanacak
            ilSelect.dispatchEvent(new Event('change'));
        });

    // İl değiştiğinde ilçe ve semtleri yükle
    ilSelect.addEventListener('change', function () {
        selectedCityId = this.value;

        // İl değiştiğinde ilçe ve semtleri sıfırla
        ilceSelect.innerHTML = '<option value="">İlçe Seçiniz</option>';
        ilceSelect.disabled = true;
        semtSelect.innerHTML = '<option value="">Mahalle Seçiniz</option>';
        semtSelect.disabled = true;

        if (selectedCityId) {
            fetch(`https://api.kadircolak.com/Konum/JSON/API/ShowDistrict?Plate=${selectedCityId}`)
                .then(response => response.json())
                .then(data => {
                    data.forEach(ilce => {
                        const option = document.createElement('option');
                        option.value = ilce.DISTRICT;
                        option.text = ilce.DISTRICT;
                        ilceSelect.appendChild(option);
                    });
                    ilceSelect.disabled = false;

                    // Seçili ilçe verilerini yükle
                    if (selectedIlce) {
                        ilceSelect.value = selectedIlce;
                        ilceSelect.dispatchEvent(new Event('change')); // İlçe seçildikten sonra mahalleleri güncelle
                    }
                });
        }
    });

    // İlçe değiştiğinde semtleri yükle
    ilceSelect.addEventListener('change', function () {
        const ilceName = this.value;

        if (ilceName && selectedCityId) {
            fetch(`https://api.kadircolak.com/Konum/JSON/API/ShowTown?Plate=${selectedCityId}&District=${encodeURIComponent(ilceName)}`)
                .then(response => response.json())
                .then(data => {
                    data.sort((a, b) => a.TOWN.localeCompare(b.TOWN));
                    semtSelect.innerHTML = '<option value="">Mahalle Seçiniz</option>';
                    data.forEach(semt => {
                        const option = document.createElement('option');
                        option.value = semt.TOWN;
                        option.text = semt.TOWN;
                        semtSelect.appendChild(option);
                    });
                    semtSelect.disabled = false;

                    // Seçili semt verilerini ayarla
                    if (selectedSemt) {
                        semtSelect.value = selectedSemt;
                    }
                });
        } else {
            semtSelect.innerHTML = '<option value="">Mahalle Seçiniz</option>';
            semtSelect.disabled = true;
        }
    });

    // Form gönderilmeden önce seçili isimleri ayarla
    document.querySelector('form').addEventListener('submit', function () {
        // Şehir ismini ayarla
        const selectedIl = ilSelect.options[ilSelect.selectedIndex].text;
        const selectedIlce = ilceSelect.options[ilceSelect.selectedIndex].text;
        const selectedSemt = semtSelect.options[semtSelect.selectedIndex].text;

        // Hidden input'lara ayarla
        document.getElementById('selectedIl').value = selectedIl;
        document.getElementById('selectedIlce').value = selectedIlce;
        document.getElementById('selectedSemt').value = selectedSemt;
    });
});


