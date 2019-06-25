package poc.boot.app.domain

import javax.persistence.*

/** Project voor de BAG Site */
@Entity
class Project(
        /**
        * Volgorde van het project
        */
        @Column(name="\"order\"")
        var order: Int,

        /** de titel in het nederlands */
        var titel_nl: String,

        /** De locatie in het nederlands */
        var locatie_nl: String,

        /** De tekst in het nederlands */
        var text_nl: String,

        /** De lijst met plaatjes */
        @JoinTable
        @OneToMany(cascade = [CascadeType.ALL])
        var images: MutableList<Image>)
{

    /** De image op de banner */
    @ManyToOne
    @JoinColumn(name="banner_image_id")
    private var bannerImage: Image

    /** De images op de frontend */
    @ManyToOne
    @JoinColumn(name="front_page_image_id")
    private var frontPageImage: Image

    /**
     * Maakt een project aan. De [bannerImageIndex] en [frontPageImageIndex] moeten geldig zijn mbt de [images].
     * @throws Exception Ongeldige index opgegeven
     */
    constructor(order: Int, titel: String, locatie: String, text: String, images: ArrayList<Image>, bannerImageIndex: Int, frontPageImageIndex: Int) : this(order, titel, locatie, text, images) {
        setBannerImage(bannerImageIndex)
        setFrontendImage(frontPageImageIndex)
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id: Int = 0

    /** de titel in het engels */
    var titel_en: String = ""

    /** de titel in het chinees */
    var titel_zh: String = ""

    /** De locatie in het engels */
    var locatie_en: String = ""

    /** De locatie in het chinees */
    var locatie_zh: String = ""

    /** De tekst in het engels */
    var text_en: String = ""

    /** De tekst in het chinees */
    var text_zh: String = ""

    init {
        bannerImage = validateAndGetFromImages(0)
        frontPageImage = validateAndGetFromImages(0)
    }

    private fun validateAndGetFromImages(index: Int): Image {
        if (images.isEmpty())
            throw Exception("No images")

        if(index > images.size - 1)
            throw Exception("Invalid index")

        return images[index]
    }

    /** De banner images */
    fun getBannerImage() : Image {
        return bannerImage
    }

    /** Set de banner op [imageIndex] */
    fun setBannerImage(imageIndex: Int){
        bannerImage = validateAndGetFromImages(imageIndex)
    }

    /** De frontend image */
    fun getFrontendImage() : Image {
        return frontPageImage
    }

    /** Set de frontendimage op [imageIndex] */
    fun setFrontendImage(imageIndex: Int){
        frontPageImage = validateAndGetFromImages(imageIndex)
    }

    fun setFrontendImage(imageUrl: String){
        images.forEach {
            if(it.url.compareTo(imageUrl,true) == 0){
                frontPageImage = it
                return
            }
        }

        throw Exception("Geen image in project met url: $imageUrl")
    }

    fun setBannerImage(imageUrl: String){
        images.forEach {
            if(it.url.compareTo(imageUrl,true) == 0){
                bannerImage = it
                return
            }
        }

      throw Exception("Geen image in project met url: $imageUrl")
    }

    fun addImage(image: Image) {
        images.add(image)
    }

    fun removeImage(image: Image){
        images.remove(image)
    }
}



