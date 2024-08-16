document.addEventListener("DOMContentLoaded", function () {
    const ilSelect = document.getElementById('il');
    const ilceSelect = document.getElementById('ilce');
    const semtSelect = document.getElementById('semt');

    // URL parametrelerini al
    const params = new URLSearchParams(window.location.search);
    const selectedCityId = params.get('il');
    const selectedIlce = params.get('ilce');
    const selectedSemt = params.get('semt');

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

            // Seçili ili yerleştirme
            if (selectedCityId) {
                ilSelect.value = selectedCityId;
                ilSelect.dispatchEvent(new Event('change')); // İl seçimini tetikle
            }
        });

    // İl değiştiğinde ilçe ve semtleri yükle
    ilSelect.addEventListener('change', function () {
        const cityId = this.value;

        // İl değiştiğinde ilçe ve semtleri sıfırla
        ilceSelect.innerHTML = '<option value="">İlçe Seçiniz</option>';
        ilceSelect.disabled = true;
        semtSelect.innerHTML = '<option value="">Mahalle Seçiniz</option>';
        semtSelect.disabled = true;

        if (cityId) {
            fetch(`https://api.kadircolak.com/Konum/JSON/API/ShowDistrict?Plate=${cityId}`)
                .then(response => response.json())
                .then(data => {
                    ilceSelect.innerHTML = '<option value="">İlçe Seçiniz</option>';
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

        if (ilceName && ilSelect.value) {
            fetch(`https://api.kadircolak.com/Konum/JSON/API/ShowTown?Plate=${ilSelect.value}&District=${encodeURIComponent(ilceName)}`)
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
});
