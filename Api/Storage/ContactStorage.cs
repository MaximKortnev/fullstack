public class ContactStorage
{
    private List<Contact> Contacts { get;set; }
    public ContactStorage() 
    {
        this.Contacts = new List<Contact>();
    }

    public bool Add(Contact contact)
    {
        contact.Id = Guid.NewGuid();
        var check = Contacts.FirstOrDefault(x => x.Id == contact.Id);
        if (check != null) return false;
        Contacts.Add(contact);
        return true;
    }

    public Contact GetById(Guid id) 
    {
        return Contacts.FirstOrDefault(x => x.Id == id);
    }
    
    public List<Contact> GetAll() => Contacts;

    public bool Delete(Guid id) 
    {
        var contact = Contacts.FirstOrDefault(x => x.Id == id);
        if(contact == null) return false;
        Contacts.Remove(contact);
        return true;
    }

    public bool Update(ContactDto contactDto, Guid id)
    {
        var contact = Contacts.FirstOrDefault(x => x.Id == id);
        if(contact != null)
        {
            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            return true;
        }
        return false;
    }
}